using System;
using System.Collections.Generic;
using System.Linq;
using ShareIt.DiscussionCtx.Events;
using ShareIt.EventStore;
using ShareIt.Infrastructure;
using ShareIt.LinkCtx.Domain;

namespace ShareIt.DiscussionCtx.Domain
{
    public class Discussion : AggregateRoot
    {
        private Topic _topic;
        private List<Participant> _participants;
        private LinkId _linkId;
        private List<Post> _posts; 

        public Discussion(IList<Event> history) : base(history) { }

        public Discussion(LinkId linkId, Topic topic, Participant initiator, List<Participant> participants)
            : base(new DiscussionId())
        {
            if (linkId == null) throw new ArgumentNullException("linkId");
            if (topic == null) throw new ArgumentNullException("topic");
            if (initiator == null) throw new ArgumentNullException("initiator");
            if (participants == null || !participants.Any()) throw new ArgumentException(String.Format("{0} cannot be null or empty", participants));

            var emailsOfParticipants = participants.Select(x => x.Email.Value).ToList();
            ApplyChange(new DiscussionOpened(new Guid(Id), linkId, topic, initiator.Email.Value, emailsOfParticipants));
        }

        public int NumberOfPosts
        {
            get { return _posts.Count; }
        }

        public void SubmitPost(EmailAddress emailOfPoster, string bodyText)
        {
            var postNumber = NumberOfPosts + 1;
            ApplyChange(new PostSubmitted(Id.ToString(), emailOfPoster, bodyText, postNumber));
        }

        private void Apply(DiscussionOpened discussion)
        {
            Id = new DiscussionId(discussion.DiscussionId);
            _topic = new Topic(discussion.Topic);
            _participants = discussion.EmailsOfParticipants.Select(x => new Participant(new EmailAddress(x))).ToList();
            _linkId = new LinkId(discussion.LinkId);
            _posts = new List<Post>();
        }

        private void Apply(PostSubmitted submittedPost)
        {
            var emailOfPoster = new EmailAddress(submittedPost.EmailAddressOfPoster);
            var post = new Post(emailOfPoster, submittedPost.BodyText, submittedPost.PostNumber);
            _posts.Add(post);
        }
    }
}