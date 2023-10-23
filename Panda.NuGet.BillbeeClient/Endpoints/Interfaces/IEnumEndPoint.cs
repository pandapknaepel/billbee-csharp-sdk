using Panda.NuGet.BillbeeClient.Model;

namespace Panda.NuGet.BillbeeClient.Endpoints.Interfaces
{
    public interface IEnumEndPoint
    {
        /// <summary>
        /// Gets a list of all payment types
        /// </summary>
        /// <returns>The list of all payment types</returns>
        Task<List<EnumEntry>> GetPaymentTypesAsync();

        /// <summary>
        /// Gets a list of all shipping carriers
        /// </summary>
        /// <returns>The list of all shipping carriers</returns>
        Task<List<EnumEntry>> GetShippingCarriersAsync();

        /// <summary>
        /// Gets a list of all shipment types
        /// </summary>
        /// <returns>The list of all shipment types</returns>
        Task<List<EnumEntry>> GetShipmentTypesAsync();
        
        /// <summary>
        /// Gets a list of all order states
        /// </summary>
        /// <returns>The list of all order states</returns>
        Task<List<EnumEntry>> GetOrderStatesAsync();
    }
}