using ShareIt.ReadCtx.Models;

namespace ShareIt.NotificationCtx.Queries
{
    public class NotificationQueryHandler
    {
        public Link Handle(LinkByIdQuery query)
        {
            using (var bucket = Persistence.Couchbase.Cluster.OpenBucket())
            {
                var link = bucket.GetDocument<Link>(query.LinkId).Content;
                return link;
            }
        }
    }
}