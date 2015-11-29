using ShareIt.EventStore;
using ShareIt.ShareLinkCtx.Domain;

namespace ShareIt.ShareLinkCtx.Commands
{
    public class ShareLinkCommandHandler
    {
        private readonly EventStoreRepository<Sender> _repository;

        public ShareLinkCommandHandler(EventStoreRepository<Sender> repository)
        {
            _repository = repository;
        }

        public void Handle(ShareLink command)
        {
            var senderId = new SenderId(command.EmailOfSender.Value);
            Sender sender = _repository.GetById(senderId);
            if (sender == default(Sender))
            {
                sender = new Sender(command.NameOfSender, command.EmailOfSender);
            }
            sender.ShareLink(command.Receivers, command.Subject, command.Link);
            _repository.Save(sender);
        }
    }
}