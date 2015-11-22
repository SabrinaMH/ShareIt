using System;
using ShareIt.NotificationCtx.Domain;

namespace ShareIt.NotificationCtx.Commands
{
    public class SendNotification
    {
        public Sender Sender { get; private set; }
        public Receiver Receiver { get; private set; }

        public SendNotification(Sender sender, Receiver receiver)
        {
            if (sender == null) throw new ArgumentNullException("sender");
            if (receiver == null) throw new ArgumentNullException("receiver");
            Sender = sender;
            Receiver = receiver;
        }
    }
}