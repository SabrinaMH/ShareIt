using Couchbase;
using ShareIt.DiscussionCtx.Events;
using ShareIt.LinkCtx.Events;
using ShareIt.ReadCtx.Models;

namespace ShareIt.ReadCtx
{
    public class ReadEventHandler
    {
        public void Handle(SharedLink @event)
        {
            using (var bucket = Persistence.Couchbase.Cluster.OpenBucket())
            {
                var link = new Link(@event.UriOflink);
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
                // Until we have the names of the other participants, we use their emails
                var discussion = new Discussion(@event.Topic, @event.NameOfInitiator, @event.EmailsOfTheOtherParticipants, link.Content.Uri);

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
                var post = new Post(@event.BodyText, @event.NameOfPoster);
                discussion.Content.Posts.Add(post);
                bucket.Upsert(discussion.Document);
            }
        }
    }
}