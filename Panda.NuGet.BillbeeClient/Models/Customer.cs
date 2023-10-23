﻿namespace Panda.NuGet.BillbeeClient.Models
{
    public class Customer
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Tel1 { get; set; }
        public string? Tel2 { get; set; }
        public int? Number { get; set; }
        public long? PriceGroupId { get; set; }
        public int? LanguageId { get; set; }
        public string? VatId { get; set; }

        /// <summary>
        /// If set, the type of the customer can be set. 0 = Endcustomer, 1 = Businesscustomer
        /// </summary>
        public byte? Type { get; set; }
    }
}
