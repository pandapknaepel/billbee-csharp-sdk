namespace Panda.NuGet.BillbeeClient.Models
{
    public class OrderItemAttribute
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public decimal Price { get; set; }
    }
}
