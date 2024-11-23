using CoreWebApiV08.API.Models.Products;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IProducts
    {
        Task<List<Products?>> GetProductsAsync();    

        Task<Products?>GetProductsByIdAsync(int id);

        Task<Products?> AddProductAsync(Products products);

        Task<Products?> UpdateProductAsync(int id,Products products);

        Task<Products?> DeleteProductAsync(int id);  
    }
}
