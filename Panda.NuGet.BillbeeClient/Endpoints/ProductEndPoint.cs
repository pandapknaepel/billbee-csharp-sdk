using System.Collections.Specialized;
using Panda.NuGet.BillbeeClient.Endpoints.Interfaces;
using Panda.NuGet.BillbeeClient.Enums;
using Panda.NuGet.BillbeeClient.Exceptions;
using Panda.NuGet.BillbeeClient.Models;

namespace Panda.NuGet.BillbeeClient.Endpoints
{
    /// <inheritdoc cref="IProductEndPoint" />
    public class ProductEndPoint : IProductEndPoint
    {
        private readonly IBillbeeRestClient _restClient;

        public ProductEndPoint(IBillbeeRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<ApiResult<List<Stock>>> GetStocksAsync()
        {
            return await _restClient.GetAsync<ApiResult<List<Stock>>>("/products/stocks");
        }

        public async Task<List<ApiResult<CurrentStockInfo>>> UpdateStockMultipleAsync(List<UpdateStock> updateStockList)
        {
            return await _restClient.PostAsync<List<ApiResult<CurrentStockInfo>>, List<UpdateStock>>(
                "/products/updatestockmultiple",
                updateStockList);
        }

        public async Task<ApiResult<CurrentStockInfo>> UpdateStockAsync(UpdateStock updateStockModel)
        {
            return await _restClient.PostAsync<ApiResult<CurrentStockInfo>, UpdateStock>("/products/updatestock",
                updateStockModel);
        }

        public async Task<ApiResult<GetReservedAmountResult>> GetReservedAmountAsync(string id, string? lookupBy = "id",
            long? stockId = null)
        {
            var parameters = new NameValueCollection
            {
                {"id", id},
                {"lookupBy", lookupBy}
            };
            if (stockId != null)
            {
                parameters.Add("stockId", stockId.Value.ToString());
            }

            return await _restClient.GetAsync<ApiResult<GetReservedAmountResult>>("/products/reservedamount",
                parameters);
        }

        public async Task UpdateStockCodeAsync(UpdateStockCode updateStockCodeModel)
        {
            await _restClient.PostAsync("/products/updatestockcode", updateStockCodeModel);
        }

        public async Task<ApiPagedResult<List<Product>>> GetProductsAsync(int page, int pageSize,
            DateTime? minCreatedAt = null)
        {
            var parameters = new NameValueCollection
            {
                {"page", page.ToString()},
                {"pageSize", pageSize.ToString()}
            };
            if (minCreatedAt != null)
            {
                parameters.Add("minCreatedAt", minCreatedAt.Value.ToString("yyyy-MM-dd"));
            }

            return await _restClient.GetAsync<ApiPagedResult<List<Product>>>("/products", parameters);
        }

        public async Task<ApiResult<Product>> GetProductAsync(string id, ProductIdType type = ProductIdType.id)
        {
            var parameters = new NameValueCollection {{"lookupBy", type.ToString()}};

            return await _restClient.GetAsync<ApiResult<Product>>($"/products/{id}", parameters);
        }

        public async Task<ApiResult<Product>> AddProductAsync(Product product)
        {
            return await _restClient.PostAsync<ApiResult<Product>, Product>("/products", product);
        }

        public async Task DeleteProductAsync(long id)
        {
            await _restClient.DeleteAsync($"/products/{id}");
        }

        public async Task<ApiResult<List<ArticleCategory>>> GetCategoriesAsync()
        {
            return await _restClient.GetAsync<ApiResult<List<ArticleCategory>>>("/products/category");
        }

        public async Task<ApiPagedResult<List<ArticleCustomFieldDefinition>>> GetCustomFieldsAsync(int page,
            int pageSize)
        {
            var parameters = new NameValueCollection
            {
                {"page", page.ToString()},
                {"pageSize", pageSize.ToString()}
            };

            return await _restClient.GetAsync<ApiPagedResult<List<ArticleCustomFieldDefinition>>>(
                "/products/custom-fields",
                parameters);
        }

        public async Task<ApiResult<ArticleCustomFieldDefinition>> GetCustomFieldAsync(long id)
        {
            return await _restClient.GetAsync<ApiResult<ArticleCustomFieldDefinition>>($"/products/custom-fields/{id}");
        }

        public async Task<ApiResult<List<string>>> GetPatchableProductFieldsAsync()
        {
            return await _restClient.GetAsync<ApiResult<List<string>>>("/products/PatchableFields");
        }

        public async Task<ApiResult<Product>> PatchArticleAsync(long id, Dictionary<string, string> fieldsToPatch)
        {
            return await _restClient.PatchAsync<ApiResult<Product>, Dictionary<string, string>>($"/products/{id}",
                fieldsToPatch);
        }

        public async Task<ApiResult<List<ArticleImage>>> GetArticleImagesAsync(long id)
        {
            return await _restClient.GetAsync<ApiResult<List<ArticleImage>>>($"/products/{id}/images");
        }

        public async Task<ApiResult<ArticleImage>> GetArticleImageAsync(long articleId, long imageId)
        {
            return await _restClient.GetAsync<ApiResult<ArticleImage>>($"/products/{articleId}/images/{imageId}");
        }

        public async Task<ApiResult<ArticleImage>> GetArticleImageAsync(long imageId)
        {
            return await _restClient.GetAsync<ApiResult<ArticleImage>>($"/products/images/{imageId}");
        }

        public async Task<ApiResult<ArticleImage>> AddArticleImageAsync(ArticleImage image)
        {
            if (image.Id != 0)
            {
                throw new InvalidValueException("To add a new image, only 0 as Id is allowed.");
            }

            return await _restClient.PutAsync<ApiResult<ArticleImage>, ArticleImage>(
                $"/products/{image.ArticleId}/images/{image.Id}", image);
        }

        public async Task<ApiResult<ArticleImage>> UpdateArticleImageAsync(ArticleImage image)
        {
            if (image.Id == 0)
            {
                throw new InvalidValueException("To update an image, the Id must not be 0.");
            }

            return await _restClient.PutAsync<ApiResult<ArticleImage>, ArticleImage>(
                $"/products/{image.ArticleId}/images/{image.Id}", image);
        }

        public async Task<ApiResult<List<ArticleImage>>> AddMultipleArticleImagesAsync(long articleId,
            List<ArticleImage> images,
            bool replace = false)
        {
            var path = $"/products/{articleId}/images?replace={replace}";
            return await _restClient.PutAsync<ApiResult<List<ArticleImage>>, List<ArticleImage>>(path, images);
        }

        public async Task DeleteArticleImageAsync(long articleId, long imageId)
        {
            await _restClient.DeleteAsync($"/products/{articleId}/images/{imageId}");
        }

        public async Task DeleteArticleImageAsync(long imageId)
        {
            await _restClient.DeleteAsync($"/products/images/{imageId}");
        }

        public async Task<ApiResult<DeletedImages>> DeleteMultipleArticleImagesAsync(List<long> imageIds)
        {
            return await _restClient.PostAsync<ApiResult<DeletedImages>, List<long>>("/products/images/delete", imageIds);
        }
    }
}