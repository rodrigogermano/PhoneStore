namespace PhoneStory.Domain.Interfaces.Mediator
{
    public interface IMediatorHandler
    {
        bool Enqueue<T>(T command, string queueName);
    }
}
