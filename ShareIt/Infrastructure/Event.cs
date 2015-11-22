namespace ShareIt.Infrastructure
{
    public abstract class Event : Message
    {
        public int Version;
    }
}