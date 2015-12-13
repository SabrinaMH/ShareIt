using System;
using System.Linq;
using ShareIt.EventStore;
using ShareIt.LinkCtx.Domain;

namespace ShareIt.LinkCtx.Commands
{
    public class LinkCommandHandler
    {
        private EventStoreRepository<Link> _repository;

        public LinkCommandHandler(EventStoreRepository<Link> repository)
        {
            _repository = repository;
        }

        public void Handle(ShareLink cmd)
        {
            var linkId = new LinkId(cmd.Link);
            var link = _repository.GetById(linkId);

            if (link == null)
            {
                var uri = new Uri(cmd.Link);
                link = new Link(uri);
            }
            var topic = new Topic(cmd.Topic);
            var emailsOfReceivers = cmd.EmailsOfReceivers.Select(x => new Receiver(new EmailAddress(x))).ToArray();
            var receivers = new ListOfReceivers(emailsOfReceivers);
            var sharer = new Sharer(new Name(cmd.NameOfSharer), new EmailAddress(cmd.EmailOfSharer));
            link.Share(topic, sharer, receivers);
            _repository.Save(link);
        }
    }
}