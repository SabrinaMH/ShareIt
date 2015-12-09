using System;
using System.Collections.Generic;
using System.Linq;

namespace ShareIt.DiscussionCtx.Domain
{
    public class ListOfReceivers
    {
        public ListOfReceivers(params Receiver[] receivers)
        {
            if (receivers == null || !receivers.Any())
                throw new ArgumentException("Need at least one receiver", "receivers");
            _receivers = receivers;
        }

        private IList<Receiver> _receivers; 

        public List<EmailAddress> GetEmails()
        {
            return _receivers.Select(x => x.Email).ToList();
        }
    }
}