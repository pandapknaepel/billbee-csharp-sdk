using Panda.NuGet.BillbeeClient.Model;

namespace Panda.NuGet.BillbeeClient.Endpoints.Interfaces
{
    /// <summary>
    /// Endpoint to register and deregister webhooks
    /// </summary>
    public interface IWebhookEndPoint
    {
        /// <summary>
        /// Deletes all existing WebHook registrations
        /// </summary>
        Task DeleteAllWebhooksAsync();

        /// <summary>
        /// Deletes one webhook, identified by the given id.
        /// </summary>
        /// <param name="id">Id of the webhook to delete.</param>
        Task DeleteWebhookAsync(string id);

        /// <summary>
        /// Gets all registered webhooks for this account
        /// </summary>
        /// <returns>List of all registered webhooks.</returns>
        Task<List<Webhook>> GetWebhooksAsync();

        /// <summary>
        /// Gets the webhook with the corresponding id
        /// </summary>
        /// <param name="id">id of the given webhook</param>
        /// <returns>The webhook itself, if the given id could be found.</returns>
        Task<Webhook> GetWebhookAsync(string id);

        /// <summary>
        /// Updates the information of a webhook
        /// </summary>
        /// <param name="webhook">The complete information of the hook, that should be updated. The webhook to update is identified by the Id parameter.</param>
        Task UpdateWebhookAsync(Webhook webhook);

        /// <summary>
        /// Queries a list of all usable filters for webhook registration.
        /// </summary>
        /// <returns>Dictionary of all registered and usable filter.</returns>
        Task<List<WebhookFilter>> GetFiltersAsync();

        /// <summary>
        /// Registers a new webhook with the given information
        /// </summary>
        /// <param name="webhook">The details of the webhook to register. The property Id must be null.</param>
        /// <returns>The registered webhook</returns>
        Task<Webhook> CreateWebhookAsync(Webhook webhook);
    }
}