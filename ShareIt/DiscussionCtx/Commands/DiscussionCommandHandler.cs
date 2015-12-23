using System.Linq;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.EventStore;
using ShareIt.LinkCtx.Domain;
using EmailAddress = ShareIt.DiscussionCtx.Domain.EmailAddress;
using Topic = ShareIt.DiscussionCtx.Domain.Topic;

namespace ShareIt.DiscussionCtx.Commands
{
    public class DiscussionCommandHandler
    {
        private readonly EventStoreRepository<Discussion> _repository;

        public DiscussionCommandHandler(EventStoreRepository<Discussion> repository)
        {
            _repository = repository;
        }

        public void Handle(OpenDiscussion openDiscussion)
        {
            var participants = openDiscussion.IdsOfParticipants.Select(x => new Participant(new EmailAddress(x))).ToList();
            var linkId = new LinkId(openDiscussion.LinkId);
            var topic = new Topic(openDiscussion.Topic);
            var initiator = new Participant(new EmailAddress(openDiscussion.IdOfInitiator));
            var discussion = new Discussion(linkId, topic, initiator, participants);
            _repository.Save(discussion);
        }

        public void Handle(SubmitPost submitPost)
        {
            var emailOfPoster = new EmailAddress(submitPost.EmailOfPoster);
            var discussionId = new DiscussionId(submitPost.DiscussionId);
            var discussion = _repository.GetById(discussionId);
            discussion.SubmitPost(emailOfPoster, submitPost.BodyText);
            _repository.Save(discussion);
        }
    }
}