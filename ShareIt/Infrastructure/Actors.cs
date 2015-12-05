using System;
using Akka.Actor;
using ShareIt.DiscussionCtx.Domain;

namespace ShareIt.Infrastructure
{
    public static class Actors
    {
        private static ActorSystem _system;
        private static IActorRef _linkCoordinator;

        public static ActorSystem System
        {
            get
            {
                if (_system == null) throw new InvalidOperationException("Actor system is not initialized");
                return _system;
            }
        }

        public static IActorRef LinkCoordinator
        {
            get
            {
                if (_linkCoordinator == null) throw new InvalidOperationException("Distribution actor is not initialized");
                return _linkCoordinator;
            }
        }


        public static void Bootstrap()
        {
            _system = ActorSystem.Create("Actors");
            _linkCoordinator = _system.ActorOf(Props.Create(() => new LinkCoordinatorActor()), "linkCoordinator");
        }

        public static void ShutDown()
        {
            if (_system != null)
            {
                _system.Shutdown();
                _system.AwaitTermination(TimeSpan.FromMinutes(1));
                _system = null;
            }
        }
    }
}