namespace PhoneStory.Domain.Entities
{
    public class Accessory : Product
    {
        protected Accessory() { }
        public Accessory(
            string displayName,
            string description,
            double price, 
            string compatibility,
            string photo):
            base(
                displayName, 
                description, 
                price,
                photo)
        {
            Compatibility = compatibility;
        }

        public string Compatibility { get; private set; }
    }
}
