namespace PhoneStory.Domain.Shared.ValueObject
{
    public class Dimension 
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        
        public Dimension(decimal length, decimal width, decimal depth)
        {
            Length = length;
            Width = width;
            Depth = depth;
        }

        public override string ToString()
        {
            return string.Format("{0} x {1} x {2}", this.Length, this.Width, this.Depth);
        }
    }
}
