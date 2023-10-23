using Panda.NuGet.BillbeeClient.Enums;
using Panda.NuGet.BillbeeClient.Model;

namespace Panda.NuGet.BillbeeClient.Endpoints.Interfaces
{
    /// <summary>
    /// EndPoint to access all product relevant methods.
    /// </summary>
    public interface IProductEndPoint
    {
        /// <summary>
        /// Query all defined stock locations
        /// </summary>
        /// <returns>Result of the operation</returns>
        Task<ApiResult<List<Stock>>> GetStocksAsync();

        /// <summary>
        /// Update the sotck amount for multiple articles
        /// </summary>
        /// <param name="updateStockList">List of UpdateStockRequest</param>
        /// <returns>Result of the operation</returns>
        Task<List<ApiResult<CurrentStockInfo>>> UpdateStockMultipleAsync(List<UpdateStock> updateStockList);

        /// <summary>
        /// Update the stock of a single product
        /// </summary>
        /// <param name="updateStockModel">Detail, which article should get which stock</param>
        /// <returns>Result of the operation</returns>
        Task<ApiResult<CurrentStockInfo>> UpdateStockAsync(UpdateStock updateStockModel);

        /// <summary>
        /// Queries the reserved amount for a single article by id or by sku
        /// </summary>
        /// <param name="id">The id or the sku of the article to query</param>
        /// <param name="lookupBy">Either the value id or the value sku to specify the meaning of the id parameter</param>
        /// <param name="stockId">Optional the stock id if the multi stock feature is enabled</param>
        /// <returns></returns>
        Task<ApiResult<GetReservedAmountResult>> GetReservedAmountAsync(string id, string? lookupBy = "id", long? stockId = null);

        /// <summary>
        /// Updates the stock code / stock location of the article
        /// </summary>
        /// <param name="updateStockCodeModel">Details, which article should be changed to which location.</param>
        /// <returns></returns>
        Task UpdateStockCodeAsync(UpdateStockCode updateStockCodeModel);

        /// <summary>
        /// Get a list of all products
        /// </summary>
        /// <param name="page">The requested page</param>
        /// <param name="pageSize">The amount of entries per page</param>
        /// <param name="minCreatedAt">When given, only articles, that are newer than the given date are supplied.</param>
        /// <returns></returns>
        Task<ApiPagedResult<List<Product>>> GetProductsAsync(int page, int pageSize, DateTime? minCreatedAt = null);

        /// <summary>
        /// Gets details of a single product
        /// </summary>
        /// <param name="id">The id of the article to deliver.</param>
        /// <param name="type">The type if the id. Whether it is the internal id or the sku.</param>
        /// <returns></returns>
        Task<ApiResult<Product>> GetProductAsync(string id, ProductIdType type = ProductIdType.id);

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<ApiResult<Product>> AddProductAsync(Product product);
                
        /// <summary>
        /// Deletes one product, identified by the given id.
        /// </summary>
        /// <param name="id">Id of the product to delete.</param>
        Task DeleteProductAsync(long id);
        
        /// <summary>
        /// Requests a list of all categories
        /// </summary>
        /// <returns>List of Categories</returns>
        Task<ApiResult<List<ArticleCategory>>> GetCategoriesAsync();
        
        /// <summary>
        /// Requests a list of all custom fields, usable in products
        /// </summary>
        /// <returns>List of CustomFields</returns>
        Task<ApiPagedResult<List<ArticleCustomFieldDefinition>>> GetCustomFieldsAsync(int page, int pageSize);

        /// <summary>
        /// Requests the definition of a custom field by using it's id
        /// </summary>
        /// <param name="id">Id of the definition to get information about</param>
        /// <returns>The definition of the entry with the given id</returns>
        Task<ApiResult<ArticleCustomFieldDefinition>> GetCustomFieldAsync(long id);

        /// <summary>
        /// Supplies a list of all fields, that can be patched using the PatchArticle- method
        /// </summary>
        /// <returns>List of field names</returns>
        Task<ApiResult<List<string>>> GetPatchableProductFieldsAsync();

        /// <summary>
        /// Patches given fields of an product
        /// </summary>
        /// <param name="id">Id of the product to patch</param>
        /// <param name="fieldsToPatch">Dictionary which uses the field name as key and the new value as value.</param>
        /// <returns></returns>
        Task<ApiResult<Product>> PatchArticleAsync(long id, Dictionary<string, string> fieldsToPatch);

        /// <summary>
        /// Collects all images of a specific article
        /// </summary>
        /// <param name="id">Id of the article to get the images.</param>
        /// <returns>List if Images.</returns>
        Task<ApiResult<List<ArticleImage>>> GetArticleImagesAsync(long id);

        /// <summary>
        /// Gets a specific image object
        /// </summary>
        /// <param name="imageId">Id of the image to gather</param>
        /// <returns>The image object.</returns>
        /// <param name="articleId">If of the article, this image belongs to.</param>
        Task<ApiResult<ArticleImage>> GetArticleImageAsync(long articleId, long imageId);

        /// <summary>
        /// Gets a specific image object
        /// </summary>
        /// <param name="imageId">Id of the image to gather</param>
        /// <returns>The image object.</returns>
        Task<ApiResult<ArticleImage>> GetArticleImageAsync(long imageId);

        /// <summary>
        /// Creates a new image
        /// </summary>
        /// <param name="image">The image definition to add</param>
        /// <returns>The added image object.</returns>
        Task<ApiResult<ArticleImage>> AddArticleImageAsync(ArticleImage image);

        /// <summary>
        /// Updates an existing image
        /// </summary>
        /// <param name="image">Definition of the image to update.</param>
        /// <returns>The updated image object.</returns>
        Task<ApiResult<ArticleImage>> UpdateArticleImageAsync(ArticleImage image);

        /// <summary>
        /// Adds muiltiple images to a specific article id.
        /// </summary>
        /// <param name="articleId">Id of the article to attach the images to.</param>
        /// <param name="images">List of images</param>
        /// <param name="replace">If true, existing images will be overwritten.</param>
        /// <returns></returns>
        Task<ApiResult<List<ArticleImage>>> AddMultipleArticleImagesAsync(long articleId, List<ArticleImage> images, bool replace = false);

        /// <summary>
        /// Deletes a single image of a specified article
        /// </summary>
        /// <param name="articleId">Id of article</param>
        /// <param name="imageId">Id of the image to delete</param>
        Task DeleteArticleImageAsync(long articleId, long imageId);

        /// <summary>
        /// Deletes a single image
        /// </summary>
        /// <param name="imageId">id of the image</param>
        Task DeleteArticleImageAsync(long imageId);

        /// <summary>
        /// Deletes multiple images
        /// </summary>
        /// <param name="imageIds">List of image ids to delete</param>
        /// <returns>Result of deletion</returns>
        Task<ApiResult<DeletedImages>> DeleteMultipleArticleImagesAsync(List<long> imageIds);
    }
}