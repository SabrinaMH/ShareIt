using Couchbase;

namespace ShareIt.Persistence
{
    public static class Couchbase
    {
        private static Cluster _cluster;

        public static Cluster Cluster
        {
            get
            {
                if (_cluster == null)
                {
                    Bootstrap();
                }
                return _cluster;
            }
        }

        private static void Bootstrap()
        {
            _cluster = new Cluster("couchbaseClients/couchbase");
        }
    }
}