using System.Text.Json.Serialization;

namespace Panda.NuGet.BillbeeClient.Model
{
    public class OrderItemProduct
    {
        /// <summary>
        /// This is for migration scenarios when the internal id of a product changes
        /// I.E. Etsy when switching to the new inventory management, the ids for variants will change.
        /// </summary>
        public string? OldId { get; set; }

        public string? Id { get; set; }
        public string? Title { get; set; }

        /// <summary>
        /// Weight of one item in gram
        /// </summary>
        public int? Weight { get; set; }

        [JsonPropertyName("SKU")]
        public string? Sku { get; set; }

        public string? SkuOrId => string.IsNullOrEmpty(Sku) ? Id : Sku;

        public bool? IsDigital { get; set; }

        public List<OrderProductImage>? Images { get; set; }

        [JsonPropertyName("EAN")]
        public string? Ean { get; set; }

        /// <summary>
        /// Optional platform specific Data as serialized JSON Object for the product
        /// </summary>
        public string? PlatformData { get; set; }

        [JsonPropertyName("TARICCode")]
        public string? TaricCode { get; set; }
        public string? CountryOfOrigin { get; set; }
        public long? BillbeeId { get; set; }
    }
}
