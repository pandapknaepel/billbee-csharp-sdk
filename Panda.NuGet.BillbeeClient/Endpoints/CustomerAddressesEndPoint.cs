using System.Collections.Specialized;
using Panda.NuGet.BillbeeClient.Endpoints.Interfaces;
using Panda.NuGet.BillbeeClient.Exceptions;
using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints
{
    /// <inheritdoc cref="ICustomerAddressesEndPoint" />
    public class CustomerAddressesEndPoint : ICustomerAddressesEndPoint
    {
        private readonly IBillbeeRestClient _restClient;

        public CustomerAddressesEndPoint(IBillbeeRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ApiPagedResult<List<CustomerAddress>>> GetCustomerAddressesAsync(int page, int pageSize)
        {
            var parameters = new NameValueCollection
            {
                {"page", page.ToString()},
                {"pageSize", pageSize.ToString()}
            };

            return await _restClient.GetAsync<ApiPagedResult<List<CustomerAddress>>>("/customer-addresses", parameters);
        }

        public async Task<ApiResult<CustomerAddress>> GetCustomerAddressAsync(long customerAddressId)
        {
            return await _restClient.GetAsync<ApiResult<CustomerAddress>>($"/customer-addresses/{customerAddressId}");
        }

        public async Task<ApiResult<CustomerAddress>> AddCustomerAddressAsync(CustomerAddress customerAddress)
        {
            return await _restClient.PostAsync<ApiResult<CustomerAddress>, CustomerAddress>("/customer-addresses",
                customerAddress);
        }

        public async Task<ApiResult<CustomerAddress>> UpdateCustomerAddressAsync(CustomerAddress customerAddress)
        {
            if (customerAddress.Id is null or <= 0)
            {
                throw new InvalidValueException("Id must not be null.");
            }

            return await _restClient.PutAsync<ApiResult<CustomerAddress>, CustomerAddress>(
                $"/customer-addresses/{customerAddress.Id.Value}", customerAddress);
        }
    }
}