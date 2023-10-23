using Panda.NuGet.BillbeeClient.Endpoints.Interfaces;
using Panda.NuGet.BillbeeClient.Model;

namespace Panda.NuGet.BillbeeClient.Endpoints
{
    /// <inheritdoc cref="ISearchEndPoint" />
    public class SearchEndPoint : ISearchEndPoint
    {
        private readonly IBillbeeRestClient _restClient;

        internal SearchEndPoint(IBillbeeRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<SearchResult> SearchTermAsync(Search search)
        {
            return await _restClient.PostAsync<SearchResult, Search>("/search", search );
        }
    }
}
