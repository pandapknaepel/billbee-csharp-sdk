using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints.Interfaces
{
    /// <summary>
    /// Endpoint to search in orders, customers and products
    /// </summary>
    public interface ISearchEndPoint
    {
        /// <summary>
        /// Executes the given search
        /// </summary>
        /// <param name="search">search parameters</param>
        /// <returns>The result of the search</returns>
        Task<SearchResult> SearchTermAsync(Search search);
    }
}