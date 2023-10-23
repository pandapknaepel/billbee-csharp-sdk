﻿namespace Panda.NuGet.BillbeeClient.Model
{
    public class Search
    {
        /// <summary>
        /// List of types, to search in should be "order", "product" and/or "customer"
        /// </summary>
        public List<string> Type { get; set; }

        /// <summary>
        /// string to search for
        /// </summary>
        public string Term { get; set; }

    }
}
