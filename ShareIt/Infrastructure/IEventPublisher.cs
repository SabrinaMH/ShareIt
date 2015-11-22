namespace ShareIt.Infrastructure
{
    public interface IEventPublisher
    {
        void Publish(Event @event);
    }
}