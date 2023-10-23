using Panda.NuGet.BillbeeClient.Endpoints.Interfaces;
using Panda.NuGet.BillbeeClient.Exceptions;
using Panda.NuGet.BillbeeClient.Model;

namespace Panda.NuGet.BillbeeClient.Endpoints
{
    /// <inheritdoc cref="IWebhookEndPoint" />
    public class WebhookEndPoint : IWebhookEndPoint
    {
        private readonly IBillbeeRestClient _restClient;

        internal WebhookEndPoint(IBillbeeRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task DeleteAllWebhooksAsync()
        {
            await _restClient.DeleteAsync("/webhooks");
        }

        public async Task DeleteWebhookAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new InvalidValueException("Property Id was not set.");
            }

            await _restClient.DeleteAsync($"/webhooks/{id}");
        }

        public async Task<List<Webhook>> GetWebhooksAsync()
        {
            return await _restClient.GetAsync<List<Webhook>>("/webhooks");
        }

        public async Task<Webhook> GetWebhookAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new InvalidValueException("Property Id was not set.");
            }

            return await _restClient.GetAsync<Webhook>($"/webhooks/{id}");
        }

        public async Task UpdateWebhookAsync(Webhook webhook)
        {
            if (string.IsNullOrWhiteSpace(webhook.Id ))
            {
                throw new InvalidValueException("Property Id was not set.");
            }

            await _restClient.PutAsync($"/webhooks/{webhook.Id}", webhook);
        }

        public async Task<List<WebhookFilter>> GetFiltersAsync()
        {
            return await _restClient.GetAsync<List<WebhookFilter>>("/webhooks/filters");
        }

        public async Task<Webhook> CreateWebhookAsync(Webhook webhook)
        {
            if (webhook.Id != null)
            {
                throw new InvalidValueException($"Property Id was set to '{webhook.Id}', but it must be null.");
            }

            if ( string.IsNullOrWhiteSpace(webhook.Secret) || webhook.Secret.Length < 32 || webhook.Secret.Length > 64)
            {
                throw new InvalidValueException("Property secret is malformed. It must meet the following criteria: Not null or whitespaces only, between 32 and 64 charackters long.");
            }

            return await _restClient.PostAsync<Webhook, Webhook>("/webhooks", webhook);
        }
    }
}
