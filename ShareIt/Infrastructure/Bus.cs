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
using ShareIt.NotificationCtx.Commands;
using ShareIt.NotificationCtx.DomainServices;
using ShareIt.ReadCtx;
using ShareIt.UserCtx.Commands;
using ShareIt.UserCtx.Domain;
using ShareIt.UserCtx.Events;

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
            var userRepository = new EventStoreRepository<User>(bus);
            var linkRepository = new EventStoreRepository<Link>(bus);

            // Command handlers //
            
            // UserCtx
            bus.RegisterHandler<RegisterUser>(cmd => new UserCommandHandler(userRepository).Handle(cmd));

            // DiscussionCtx
            bus.RegisterHandler<OpenDiscussion>(cmd => new DiscussionCommandHandler(discussionRepository).Handle(cmd));
            bus.RegisterHandler<SubmitPost>(cmd => new DiscussionCommandHandler(discussionRepository).Handle(cmd));

            // LinkCtx
            bus.RegisterHandler<ShareLink>(
                cmd => new LinkCommandHandler(linkRepository).Handle(cmd));

            //  NotificationCtx
            var mailService = new MailService(new SmtpClient(Settings.SmtpClientHost), Settings.ReadCredentials());
            bus.RegisterHandler<SendLinkSharedNotification>(cmd => new NotificationCommandHandler(mailService).Handle(cmd));


            // Event handlers //
           
            // DiscussionCtx

            // LinkCtx
            // Use email as name until poster is registered as a user
            bus.RegisterHandler<SharedLink>(@event => new DiscussionEventHandler().Handle(@event));

            // NotificationCtx
            bus.RegisterHandler<DiscussionOpened>(@event => new NotificationEventHandler().Handle(@event));

            // ReadCtx
            bus.RegisterHandler<DiscussionOpened>(@event => new ReadEventHandler().Handle(@event));
            bus.RegisterHandler<PostSubmitted>(@event => new ReadEventHandler().Handle(@event));
            bus.RegisterHandler<SharedLink>(@event => new ReadEventHandler().Handle(@event));
            bus.RegisterHandler<UserRegistered>(@event => new ReadEventHandler().Handle(@event));

            return bus;
        }
    }
}