namespace ShareIt.Infrastructure
{
    public interface ICommandSender
    {
        void Send(Command command);
    }
}