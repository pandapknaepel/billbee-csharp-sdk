using Panda.NuGet.BillbeeClient.Model;
using Panda.NuGet.BillbeeClient.Model.Rechnungsdruck.WebApp.Model.Api;

namespace Panda.NuGet.BillbeeClient.Endpoints.Interfaces
{
    /// <summary>
    /// EndPoint for generation of shipments
    /// </summary>
    public interface IShipmentEndPoint
    {
        /// <summary>
        /// Get a list of all shipments optionally filtered by date.
        /// </summary>
        /// <param name="page">Specifies the page to request.</param>
        /// <param name="pageSize">Specifies the pageSize. Defaults to 50, max value is 250</param>
        /// <param name="createdAtMin">Specifies the oldest shipment date to include in the response</param>
        /// <param name="createdAtMax">Specifies the newest shipment date to include in the response</param>
        /// <param name="orderId">Get shipments for this order only.</param>
        /// <param name="minimumShipmentId">Get Shipments with a shipment greater or equal than this id. New shipments have a greater id than older shipments.</param>
        /// <param name="shippingProviderId">Get Shippings for the specified shipping provider only.</param>
        /// <returns>A list of shipments.</returns>
        Task<ApiPagedResult<List<Shipment>>> GetShipmentsAsync(int page = 1, int pageSize = 50, DateTime? createdAtMin = null,
            DateTime? createdAtMax = null, long? orderId = null, long? minimumShipmentId = null,
            long? shippingProviderId = null);
        
        /// <summary>
        /// Requests a list of all available shipping providers and their products.
        /// </summary>
        /// <returns>List of shipping providers.</returns>
        Task<List<ShippingProvider>> GetShippingProviderAsync();

        /// <summary>
        /// Creates a new shipment.
        /// </summary>
        /// <param name="shipment">The shipment specification, that should be created.</param>
        /// <returns>The result of the shipment <see cref="ShipmentResult"/></returns>
        Task<ApiResult<ShipmentResult>> PostShipmentAsync(PostShipment shipment);

        Task<ApiResult<ShipmentWithLabelResult>> ShipOrderWithLabelAsync(ShipmentWithLabel shipmentRequest);

        /// <summary>
        /// Delivers a list of all registered shipping carriers
        /// </summary>
        /// <returns>List of available shipping carriers</returns>
        Task<List<ShippingCarrier>> GetShippingCarriersAsync();
    }
}