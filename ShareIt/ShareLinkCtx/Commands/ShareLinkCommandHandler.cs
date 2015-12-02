using ShareIt.EventStore;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.ShareLinkCtx.Commands
{
    public class ShareLinkCommandHandler
    {
        private readonly EventStoreRepository<Sharer> _repository;

        public ShareLinkCommandHandler(EventStoreRepository<Sharer> repository)
        {
            _repository = repository;
        }

        public void Handle(ShareLink command)
        {
            var sharerId = new SharerId(command.EmailOfSharer.Value);
            Sharer sharer = _repository.GetById(sharerId);
            if (sharer == null)
            {
                sharer = new Sharer(command.NameOfSharer, command.EmailOfSharer);
            }
            sharer.ShareLink(command.Receivers, command.Subject, command.Link);
            _repository.Save(sharer);
        }
    }
}