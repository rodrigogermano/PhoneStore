namespace PhoneStore.Application.Cqrs.Commands
{
    public class UpdateProductCommand : ProductCommand
    {
        public const string CommandQueueName = "update-product-command-queue";
        public override string QueueName => CommandQueueName;
    }
}
