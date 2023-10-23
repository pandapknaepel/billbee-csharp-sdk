using Panda.NuGet.BillbeeClient.Endpoints.Interfaces;
using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints
{
    /// <inheritdoc cref="ICloudStoragesEndPoint" />
    public class CloudStoragesEndPoint : ICloudStoragesEndPoint
    {
        private readonly IBillbeeRestClient _restClient;

        public CloudStoragesEndPoint(IBillbeeRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ApiResult<List<CloudStorage>>> GetCloudStorageListAsync()
        {
            return await _restClient.GetAsync<ApiResult<List<CloudStorage>>>("/cloudstorages");
        }
    }
}
