using ShareIt.DiscussionCtx.Domain;
using ShareIt.EventStore;

namespace ShareIt.DiscussionCtx.Commands
{
    public class DiscussionCommandHandler
    {
        private EventStoreRepository<Link> _repository;

        //private EventStoreRepository<Sharer> _repository;

        //public DiscussionCommandHandler(EventStoreRepository<Sharer> repository)
        //{
        //    _repository = repository;
        //}

        //public void Handle(ShareLink cmd)
        //{


        //    var sharerId = new SharerId(cmd.EmailOfSharer.Value);
        //    Sharer sharer = _repository.GetById(sharerId);
        //    if (sharer == null)
        //    {
        //        sharer = new Sharer(cmd.NameOfSharer, cmd.EmailOfSharer);
        //    }

        //    sharer.ShareLink(cmd.Receivers, cmd.Topic, cmd.Link);
        //    _repository.Save(sharer);
        //}
    }
}