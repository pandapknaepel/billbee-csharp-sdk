﻿namespace Panda.NuGet.BillbeeClient.Models
{
    public class Stock
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
    }
}