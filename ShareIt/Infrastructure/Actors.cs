using System;
using Akka.Actor;

namespace ShareIt.Infrastructure
{
    public static class Actors
    {
        private static ActorSystem _system;

        public static ActorSystem System
        {
            get
            {
                if (_system == null) throw new InvalidOperationException("Actor system is not initialized");
                return _system;
            }
        }

        public static void Bootstrap()
        {
            _system = ActorSystem.Create("DiscussionActorSystem");
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