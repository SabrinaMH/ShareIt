using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading;
using ShareIt.DiscussionCtx.Commands;
using ShareIt.DiscussionCtx.Domain;
using ShareIt.DiscussionCtx.Events;
using ShareIt.EventStore;
using ShareIt.LinkCtx.Commands;
using ShareIt.LinkCtx.Domain;
using ShareIt.LinkCtx.Events;
using ShareIt.NotificationCtx;
using ShareIt.NotificationCtx.DomainServices;
using ShareIt.ReadCtx;

namespace ShareIt.Infrastructure
{
    public class Bus : ICommandSender, IEventPublisher
    {
        private static Bus _instance;
        private readonly Dictionary<Type, List<Action<Message>>> _routes = new Dictionary<Type, List<Action<Message>>>();

        public static Bus Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Bootstrap();
                }
                return _instance;
            }
        }

        public void Send(Command command)
        {
            List<Action<Message>> handlers;

            if (_routes.TryGetValue(command.GetType(), out handlers))
            {
                if (handlers.Count != 1) throw new InvalidOperationException("cannot send to more than one handler");
                handlers[0](command);
            }
            else
            {
                throw new InvalidOperationException("" +
                                                    "no handler registered");
            }
        }

        public void Publish(Event @event)
        {
            List<Action<Message>> handlers;

            if (!_routes.TryGetValue(@event.GetType(), out handlers)) return;

            foreach (var handler in handlers)
            {
                //dispatch on thread pool for added awesomeness
                Action<Message> handler1 = handler;
                ThreadPool.QueueUserWorkItem(x => handler1(@event));
            }
        }

        public void RegisterHandler<T>(Action<T> handler) where T : Message
        {
            List<Action<Message>> handlers;

            if (!_routes.TryGetValue(typeof (T), out handlers))
            {
                handlers = new List<Action<Message>>();
                _routes.Add(typeof (T), handlers);
            }

            handlers.Add((x => handler((T) x)));
        }

        public static Bus Bootstrap()
        {
            var bus = new Bus();
            var discussionRepository = new EventStoreRepository<Discussion>(bus);

            // Command handlers

            // DiscussionCtx
            bus.RegisterHandler<OpenDiscussion>(cmd => new DiscussionCommandHandler(discussionRepository).Handle(cmd));
            bus.RegisterHandler<SubmitPost>(cmd => new DiscussionCommandHandler(discussionRepository).Handle(cmd));

            // LinkCtx
            bus.RegisterHandler<ShareLink>(
                cmd => new LinkCommandHandler(new EventStoreRepository<Link>(bus)).Handle(cmd));


            // Event handlers

            // LinkCtx
            bus.RegisterHandler<SharedLink>(@event => new DiscussionEventHandler().Handle(@event));

            // NotificationCtx
            var mailService = new MailService(new SmtpClient(Settings.SmtpClientHost), Settings.ReadCredentials());
            bus.RegisterHandler<DiscussionOpened>(@event => new NotificationEventHandler(mailService).Handle(@event));

            // ReadCtx
            bus.RegisterHandler<DiscussionOpened>(@event => new ReadEventHandler().Handle(@event));
            bus.RegisterHandler<PostSubmitted>(@event => new ReadEventHandler().Handle(@event));
            bus.RegisterHandler<SharedLink>(@event => new ReadEventHandler().Handle(@event));

            return bus;
        }
    }
}