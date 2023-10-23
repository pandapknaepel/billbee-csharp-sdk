﻿namespace Panda.NuGet.BillbeeClient.Model
{
    /// <summary>
    /// Image information for an article image
    /// </summary>
    public class ArticleImage
    {
        /// <summary>
        ///  The url, this image is located
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// The id of this image
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Path of external thumbnail, will be ignored, if posting to billbee.
        /// </summary>
        public string? ThumbPathExt { get; set; }

        /// <summary>
        /// Url of the thumbail, will be ignored, if posting to billbee.
        /// </summary>
        public string? ThumbUrl { get; set; }

        /// <summary>
        /// If more than one image is given, the position defines the order.
        /// </summary>
        public byte? Position { get; set; }

        /// <summary>
        /// Defines, wether this is default image, or not.
        /// </summary>
        public bool? IsDefault { get; set; }

        /// <summary>
        /// The id of the article, this image belongs to.
        /// </summary>
        public long ArticleId { get; set; }
    }
}
