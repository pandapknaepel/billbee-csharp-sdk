using System.Collections.Specialized;
using Panda.NuGet.BillbeeClient.Endpoints.Interfaces;
using Panda.NuGet.BillbeeClient.Enums;
using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints
{
    /// <inheritdoc cref="IEventEndPoint" />
    public class EventEndPoint : IEventEndPoint
    {
        private readonly IBillbeeRestClient _restClient;

        internal EventEndPoint(IBillbeeRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ApiPagedResult<List<Event>>> GetEventsAsync(
            DateTime? minDate = null,
            DateTime? maxDate = null,
            int page = 1,
            int pageSize = 50,
            List<EventTypeEnum>? typeIds = null,
            long? orderId = null)
        {
            var parameters = new NameValueCollection();

            if (minDate.HasValue)
            {
                parameters.Add("minDate", minDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (maxDate.HasValue)
            {
                parameters.Add("maxDate", maxDate.Value.ToString("yyyy-MM-dd"));
            }

            parameters.Add("page", page.ToString());
            parameters.Add("pageSize", pageSize.ToString());


            if (orderId != null)
            {
                parameters.Add("orderId", orderId.ToString());
            }

            var index = 0;
            if (typeIds != null)
            {
                foreach (var typeId in typeIds)
                {
                    parameters.Add($"typeId[{index}]", ((int) typeId).ToString());
                    index++;
                }
            }

            return await _restClient.GetAsync<ApiPagedResult<List<Event>>>("/events", parameters);
        }
    }
}
