﻿namespace Panda.NuGet.BillbeeClient.Models
{
    public class UpdateStockCode
    {
        public string? Sku { get; set; }
        public long? StockId { get; set; }
        public string? StockCode { get; set; }
    }
}
