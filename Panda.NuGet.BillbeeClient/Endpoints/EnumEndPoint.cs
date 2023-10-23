using Panda.NuGet.BillbeeClient.Endpoints.Interfaces;
using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints
{
    public class EnumEndPoint : IEnumEndPoint
    {
        private readonly IBillbeeRestClient _restClient;

        internal EnumEndPoint(IBillbeeRestClient restClient)
        {
            _restClient = restClient;
        }
        
        public async Task<List<EnumEntry>> GetPaymentTypesAsync()
        {
            return await _restClient.GetAsync<List<EnumEntry>>("/enums/paymenttypes");
        }

        public async Task<List<EnumEntry>> GetShippingCarriersAsync()
        {
            return await _restClient.GetAsync<List<EnumEntry>>("/enums/shippingcarriers");
        }

        public async Task<List<EnumEntry>> GetShipmentTypesAsync()
        {
            return await _restClient.GetAsync<List<EnumEntry>>("/enums/shipmenttypes");
        }

        public async Task<List<EnumEntry>> GetOrderStatesAsync()
        {
            return await _restClient.GetAsync<List<EnumEntry>>("/enums/orderstates");
        }
    }
}