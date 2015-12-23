using System.Collections.Generic;
using Couchbase;
using Couchbase.Core;
using ShareIt.DiscussionCtx.Events;
using ShareIt.LinkCtx.Events;
using ShareIt.ReadCtx.Models;
using ShareIt.UserCtx.Events;

namespace ShareIt.ReadCtx
{
    public class ReadEventHandler
    {
        public void Handle(SharedLink @event)
        {
            using (var bucket = Persistence.Couchbase.Cluster.OpenBucket())
            {
                var link = new Link(@event.UrlOflink);
                var document = new Document<Link>
                {
                    Id = @event.LinkId,
                    Content = link
                };
                bucket.Insert(document);
            }
        }

        public void Handle(DiscussionOpened @event)
        {
            using (var bucket = Persistence.Couchbase.Cluster.OpenBucket())
            {
                var link = bucket.GetDocument<Link>(@event.LinkId);
                var user = bucket.GetDocument<User>(@event.EmailOfInitiator);
                // Use email if participant isn't registered within the system
                var nameOfInitiator = (user != null) ? user.Content.Name : @event.EmailOfInitiator;
                var namesOfParticipants = new List<string>();
                foreach (var emailOfParticipant in @event.EmailsOfParticipants)
                {
                    var participant = bucket.GetDocument<User>(emailOfParticipant);
                    var nameOfParticipant = (participant != null) ? participant.Content.Name : emailOfParticipant;
                    namesOfParticipants.Add(nameOfParticipant);
                }
                var discussion = new Discussion(@event.Topic, nameOfInitiator,
                    namesOfParticipants, link.Content.Url);

                var document = new Document<Discussion>
                {
                    Id = @event.DiscussionId.ToString(),
                    Content = discussion
                };
                bucket.Insert(document);
            }
        }

        public void Handle(PostSubmitted @event)
        {
            using (var bucket = Persistence.Couchbase.Cluster.OpenBucket())
            {
                var discussion = bucket.GetDocument<Discussion>(@event.DiscussionId);
                var post = new Post(@event.BodyText, @event.EmailAddressOfPoster, @event.PostNumber);
                discussion.Content.Posts.Add(post);
                bucket.Upsert(discussion.Document);
            }
        }

        public void Handle(UserRegistered @event)
        {
            using (var bucket = Persistence.Couchbase.Cluster.OpenBucket())
            {
                var user = new User(@event.Name, @event.Email);
                var document = new Document<User>
                {
                    Id = @event.UserId,
                    Content = user
                };
                bucket.Insert(document);
            }
        }
    }
}