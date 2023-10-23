using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints.Interfaces
{
    /// <summary>
    /// EndPoint to access all cloud storage relevant methods.
    /// </summary>
    public interface ICloudStoragesEndPoint
    {
        /// <summary>
        /// Requests a list of all available cloud storages of the user
        /// </summary>
        /// <returns>List of cloud storages.</returns>
        Task<ApiResult<List<CloudStorage>>> GetCloudStorageListAsync();
    }
}