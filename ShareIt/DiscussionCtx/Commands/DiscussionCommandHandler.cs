using System.Linq;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.EventStore;
using ShareIt.LinkCtx.Domain;
using EmailAddress = ShareIt.DiscussionCtx.Domain.EmailAddress;
using Name = ShareIt.DiscussionCtx.Domain.Name;
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
            var participants = openDiscussion.EmailsOfParticipants.Select(x => new Participant(new EmailAddress(x))).ToList();
            var linkId = new LinkId(openDiscussion.LinkId);
            var topic = new Topic(openDiscussion.Topic);
            var initiator = new Participant(new Name(openDiscussion.NameOfInitiator), new EmailAddress(openDiscussion.EmailOfInitiator));
            var discussion = new Discussion(linkId, topic, initiator, participants);
            _repository.Save(discussion);
        }

        public void Handle(SubmitPost submitPost)
        {
            var discussionId = new DiscussionId(submitPost.DiscussionId);
            var discussion = _repository.GetById(discussionId);
            var poster = new Poster(new Name(submitPost.NameOfPoster), new EmailAddress(submitPost.EmailOfPoster));
            var post = new Post(poster, submitPost.BodyText);
            discussion.SubmitPost(post);
            _repository.Save(discussion);
        }
    }
}