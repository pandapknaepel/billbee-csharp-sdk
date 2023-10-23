﻿namespace Panda.NuGet.BillbeeClient.Model
{
    /// <summary>
    /// Information about a category of an article
    /// </summary>
    public class ArticleCategory
    {
        /// <summary>
        /// The name of the category
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The internal id of the category
        /// </summary>
        public long? Id { get; set; }
    }
}
