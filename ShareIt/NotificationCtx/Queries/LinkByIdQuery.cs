using System;

namespace ShareIt.NotificationCtx.Queries
{
    public class LinkByIdQuery
    {
        public string LinkId { get; private set; }

        public LinkByIdQuery(string linkId)
        {
            if (String.IsNullOrWhiteSpace(linkId))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", linkId));
            
            LinkId = linkId;
        }
    }
}