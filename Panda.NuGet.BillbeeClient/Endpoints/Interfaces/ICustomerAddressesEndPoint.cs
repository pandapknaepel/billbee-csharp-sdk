using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints.Interfaces
{
    /// <summary>
    /// Endpoint to access customer addresses
    /// </summary>
    public interface ICustomerAddressesEndPoint
    {
        /// <summary>
        /// Queries a list of customers addresses
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="pageSize">page size</param>
        /// <returns>List of customers on the given page.</returns>
        Task<ApiPagedResult<List<CustomerAddress>>> GetCustomerAddressesAsync(int page, int pageSize);

        /// <summary>
        /// Gets a single customer address by its id
        /// <param name="customerAddressId">customer address id</param>
        /// </summary>
        Task<ApiResult<CustomerAddress>> GetCustomerAddressAsync(long customerAddressId);

        /// <summary>
        /// Creates a new customer address
        /// <param name="customerAddress">customer address model</param>
        /// </summary>
        Task<ApiResult<CustomerAddress>> AddCustomerAddressAsync(CustomerAddress customerAddress);

        /// <summary>
        /// Updates a new customer address
        /// </summary>
        /// <param name="customerAddress">customer address model</param>
        Task<ApiResult<CustomerAddress>> UpdateCustomerAddressAsync(CustomerAddress customerAddress);
    }
}