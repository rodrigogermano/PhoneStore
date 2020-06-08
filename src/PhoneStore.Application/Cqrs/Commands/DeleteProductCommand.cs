namespace PhoneStore.Application.Cqrs.Commands
{
    public class DeleteProductCommand : ProductCommand
    {
        public const string CommandQueueName = "delete-product-command-queue";
        public override string QueueName => CommandQueueName;
    }
}
