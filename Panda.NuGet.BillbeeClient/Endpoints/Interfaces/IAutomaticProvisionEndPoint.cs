using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints.Interfaces
{
    /// <summary>
    /// EndPoint to access functions for auto provisioning
    /// </summary>
    public interface IAutomaticProvisionEndPoint
    {
        /// <summary>
        /// Creates a new user account in billbee
        /// </summary>
        /// <param name="createAccountContainer">The definition of the account, that shoule be created</param>
        /// <returns>The password, user-id and one time loging url.</returns>
        Task<ApiResult<CreateUserResult>> CreateAccountAsync(Account createAccountContainer);

        /// <summary>
        /// Calls the terms and coditions of use for billbee
        /// </summary>
        /// <returns>The urls of all needed information.</returns>
        Task<ApiResult<TermsResult>> TermsInfoAsync();
    }
}