using System.Linq;
using Couchbase;
using ShareIt.DiscussionCtx.Events;
using ShareIt.ReadCtx.Models;

namespace ShareIt.ReadCtx
{
    public class ReadEventHandler
    {
        public void Handle(DiscussionOpened @event)
        {
            using (var bucket = Persistence.Couchbase.Cluster.OpenBucket())
            {
                var initiator = new Participant(@event.EmailOfInitiator);
                var theOtherParticipants = @event.EmailsOfTheOtherParticipants.Select(x => new Participant(x)).ToList();

                var discussion = new Discussion(@event.Topic, initiator, theOtherParticipants, @event.LinkId);

                var document = new Document<Discussion>
                {
                    Id = @event.DiscussionId.ToString(),
                    Content = discussion
                };
                bucket.Upsert(document);
            }
        }

        public void Handle(PostSubmitted @event)
        {
            using (var bucket = Persistence.Couchbase.Cluster.OpenBucket())
            {
                var discussion = bucket.GetDocument<Discussion>(@event.DiscussionId);
                var post = new Post(@event.BodyText, new Poster(@event.EmailAddressOfPoster, @event.NameOfPoster));
                discussion.Content.Posts.Add(post);
                bucket.Upsert(discussion.Document);
            }
        }
    }
}