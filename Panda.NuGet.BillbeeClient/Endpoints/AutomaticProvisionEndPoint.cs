using Panda.NuGet.BillbeeClient.Endpoints.Interfaces;
using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints
{
    /// <inheritdoc cref="IAutomaticProvisionEndPoint" />
    public class AutomaticProvisionEndPoint : IAutomaticProvisionEndPoint
    {
        private readonly IBillbeeRestClient _restClient;

        public AutomaticProvisionEndPoint(IBillbeeRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ApiResult<CreateUserResult>> CreateAccountAsync(Account createAccountContainer)
        {
            return await _restClient.PostAsync<ApiResult<CreateUserResult>, Account>("/automaticprovision/createaccount", createAccountContainer);
        }

        public async Task<ApiResult<TermsResult>> TermsInfoAsync()
        {
            return await _restClient.GetAsync<ApiResult<TermsResult>>("/automaticprovision/termsinfo");
        }
    }
}
