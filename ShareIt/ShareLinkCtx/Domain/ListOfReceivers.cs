using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShareIt.ShareLinkCtx.Domain
{
    public class ListOfReceivers
    {
        public IList<Receiver> Receivers { get; private set; }

        public ListOfReceivers(params Receiver[] receivers)
        {
            if (receivers == null || !receivers.Any()) throw new ArgumentException("Need at least one receiver", "receivers");
            Receivers = receivers;
        }

        public List<EmailAddress> GetEmails()
        {
            return Receivers.Select(x => x.Email).ToList();
        } 
    }
}