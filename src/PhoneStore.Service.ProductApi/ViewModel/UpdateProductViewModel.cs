namespace PhoneStore.Service.ProductApi.ViewModel
{
    public class UpdateProductViewModel
    {
        public  string Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public double Capacity { get; set; }
        public int Color { get; set; }
        public string Display { get; set; }
        public string Compatibility { get; set; }
    }
}
