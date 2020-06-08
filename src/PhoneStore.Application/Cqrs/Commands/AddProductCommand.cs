namespace PhoneStore.Application.Cqrs.Commands
{
    public class AddProductCommand : ProductCommand
    {
        public const string CommandQueueName = "add-product-command-queue";
        public override string QueueName => CommandQueueName;
    }
}
