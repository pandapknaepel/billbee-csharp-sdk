﻿namespace Panda.NuGet.BillbeeClient.Models
{
    /// <summary>
    /// Defines the dimnesion of an package, that should be used for shipping an order.
    /// </summary>
    public class ShipmentDimensions
    {
        /// <summary>
        /// Length of the package in cm
        /// </summary>
        public decimal length { get; set; }
        /// <summary>
        /// Width of the package in cm
        /// </summary>
        public decimal width { get; set; }
        /// <summary>
        /// Height of the package in cm
        /// </summary>
        public decimal height { get; set; }
    }
}
