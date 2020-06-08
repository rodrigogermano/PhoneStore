using PhoneStory.Domain.Shared.Enums;

namespace PhoneStory.Domain.Entities
{
    public class CellPhone : Product
    {
        protected CellPhone() { }
        public CellPhone(
            string displayName, 
            string description, 
            double price,
            double capacity,
            EColor color, 
            string display,
            string photo)
            : base(
                  displayName, 
                  description, 
                  price,
                  photo)
        {
            Capacity = capacity;
            Color = color;
            Display = display;
        }

        public double Capacity { get; private set; }
        public EColor Color { get; private set; }
        public string Display { get; private set; }        
    }
}
