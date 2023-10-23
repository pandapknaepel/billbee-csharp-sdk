using System.Collections.Specialized;
using Panda.NuGet.BillbeeClient.Endpoints.Interfaces;
using Panda.NuGet.BillbeeClient.Models;
using Panda.NuGet.BillbeeClient.Models.Rechnungsdruck.WebApp.Model.Api;

namespace Panda.NuGet.BillbeeClient.Endpoints
{
    /// <inheritdoc cref="IShipmentEndPoint" />
    public class ShipmentEndPoint : IShipmentEndPoint
    {
        private readonly IBillbeeRestClient _restClient;

        internal ShipmentEndPoint(IBillbeeRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ApiPagedResult<List<Shipment>>> GetShipmentsAsync(int page = 1, int pageSize = 50,
            DateTime? createdAtMin = null, DateTime? createdAtMax = null, long? orderId = null,
            long? minimumShipmentId = null, long? shippingProviderId = null)
        {
            var parameters = new NameValueCollection
            {
                {"page", page.ToString()},
                {"pageSize", pageSize.ToString()}
            };
            if (createdAtMin != null)
            {
                parameters.Add("createdAtMin", createdAtMin.Value.ToString("yyyy-MM-dd"));
            }

            if (createdAtMax != null)
            {
                parameters.Add("createdAtMax", createdAtMax.Value.ToString("yyyy-MM-dd"));
            }

            if (orderId != null)
            {
                parameters.Add("orderId", orderId.Value.ToString());
            }

            if (minimumShipmentId != null)
            {
                parameters.Add("minimumShipmentId", minimumShipmentId.Value.ToString());
            }

            if (shippingProviderId != null)
            {
                parameters.Add("shippingProviderId", shippingProviderId.Value.ToString());
            }

            return await _restClient.GetAsync<ApiPagedResult<List<Shipment>>>("/shipment/shipments", parameters);
        }

        public async Task<List<ShippingProvider>> GetShippingProviderAsync()
        {
            return await _restClient.GetAsync<List<ShippingProvider>>("/shipment/shippingproviders");
        }

        public async Task<ApiResult<ShipmentResult>> PostShipmentAsync(PostShipment shipment)
        {
            return await _restClient.PostAsync<ApiResult<ShipmentResult>, PostShipment>("/shipment/shipment", shipment);
        }

        public async Task<ApiResult<ShipmentWithLabelResult>> ShipOrderWithLabelAsync(ShipmentWithLabel shipmentRequest)
        {
            return await _restClient.PostAsync<ApiResult<ShipmentWithLabelResult>, ShipmentWithLabel>("/shipment/shipwithlabel", shipmentRequest);
        }

        public async Task<List<ShippingCarrier>> GetShippingCarriersAsync()
        {
            return await _restClient.GetAsync<List<ShippingCarrier>>("/shipment/shippingcarriers");
        }
    }
}