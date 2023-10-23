﻿namespace Panda.NuGet.BillbeeClient.Model
{
    public class StockArticle
    {
        public string Name { get; set; }
        public long StockId { get; set; }
        public decimal? StockCurrent { get; set; }
        public decimal? StockWarning { get; set; }
        public string StockCode { get; set; }
        public decimal? UnfulfilledAmount { get; set; }
        public decimal? StockDesired { get; set; }
    }
}
