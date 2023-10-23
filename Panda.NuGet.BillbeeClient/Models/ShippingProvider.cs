using System.Text.Json.Serialization;

namespace Panda.NuGet.BillbeeClient.Models
{
    public class ShippingProvider
    {
        /// <summary>
        /// internal id of this provider
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Name of this provider
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Available products
        /// </summary>
        [JsonPropertyName("naproductsme")]
        public List<ShippingProduct>? Products { get; set; }
    }
}
