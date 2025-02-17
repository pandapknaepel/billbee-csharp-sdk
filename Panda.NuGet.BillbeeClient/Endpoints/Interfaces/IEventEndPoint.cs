﻿using Panda.NuGet.BillbeeClient.Enums;
using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints.Interfaces
{
    /// <summary>
    /// EndPoint to access event related functions
    /// </summary>
    public interface IEventEndPoint
    {
        /// <summary>
        ///  Calls a list of events for the selected account.
        /// </summary>
        /// <param name="minDate">Date to select only newer events</param>
        /// <param name="maxDate">Date to select only older events</param>
        /// <param name="page">The page, selected</param>
        /// <param name="pageSize">The events per page</param>
        /// <param name="typeIds">Defines, which types if events should be listet</param>
        /// <param name="orderId">If given, only events of this order will be supplied.</param>
        /// <returns>List of the events, matching the search criteria.</returns>
        Task<ApiPagedResult<List<Event>>> GetEventsAsync(
            DateTime? minDate = null,
            DateTime? maxDate = null,
            int page = 1,
            int pageSize = 50,
            List<EventTypeEnum>? typeIds = null,
            long? orderId = null);
    }
}