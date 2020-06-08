using PhoneStory.Domain.Shared.Entities;
using PhoneStory.Domain.Shared.ValueObject;

namespace PhoneStory.Domain.Entities
{
    public abstract class Product : TEntity
    {
        protected Product() { }
        public Product(
            string displayName, 
            string description, 
            double price,
            string photo)
        {
            DisplayName = displayName;
            Description = description;
            Price = price;
            Photo = photo;
        }

        public void SetDimensions(decimal length, decimal width, decimal depth)
        {
            var _dimensions = new Dimension(length, width, depth);
        }

        public string DisplayName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public Dimension Dimensions { get; set; }
    }
}
