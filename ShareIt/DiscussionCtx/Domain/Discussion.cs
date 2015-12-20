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

        public Discussion(LinkId linkId, Topic topic, Participant initiator, List<Participant> theOtherParticipants)
            : base(new DiscussionId())
        {
            if (linkId == null) throw new ArgumentNullException("linkId");
            if (topic == null) throw new ArgumentNullException("topic");
            if (initiator == null) throw new ArgumentNullException("initiator");
            if (theOtherParticipants == null || !theOtherParticipants.Any()) throw new ArgumentException(String.Format("{0} cannot be null or empty", theOtherParticipants));

            var emailsOfParticipants = theOtherParticipants.Select(x => x.Email.Value).ToList();
            ApplyChange(new DiscussionOpened(new Guid(Id), linkId, topic, initiator.Name, initiator.Email.Value, emailsOfParticipants));
        }

        public void SubmitPost(Post post)
        {
            ApplyChange(new PostSubmitted(Id.ToString(), post.Poster.Name, post.Poster.EmailAddress, post.BodyText));
        }

        private void Apply(DiscussionOpened discussion)
        {
            Id = new DiscussionId(discussion.DiscussionId);
            _topic = new Topic(discussion.Topic);
            _participants = discussion.EmailsOfTheOtherParticipants.Select(x => new Participant(new EmailAddress(x))).ToList();
            _linkId = new LinkId(discussion.LinkId);
            _posts = new List<Post>();
        }

        private void Apply(PostSubmitted submittedPost)
        {
            var poster = new Poster(new Name(submittedPost.NameOfPoster), new EmailAddress(submittedPost.EmailAddressOfPoster));
            var post = new Post(poster, submittedPost.BodyText);
            _posts.Add(post);
        }
    }
}