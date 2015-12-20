using Couchbase;
using ShareIt.Controllers.Models;
using ShareIt.ReadCtx.Models;

namespace ShareIt.ReadCtx.Queries
{
    public class DiscussionQueryHandler
    {
        public Discussion Handle(DiscussionByIdQuery query)
        {
            using (var bucket = Persistence.Couchbase.Cluster.OpenBucket())
            {
                var discussion = bucket.GetDocument<Discussion>(query.DiscussionId.ToString()).Content;
                return discussion;
            }
        }
    }
}