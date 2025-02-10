using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Products;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLProducts : IProducts
    {
        private readonly DatabaseContext _db;

        public SQLProducts( DatabaseContext db)
        {
            _db = db;
        }
        public async Task<Products?> AddProductAsync(Products products)
        {
            await _db.TblProducts.AddAsync(products);
            await _db.SaveChangesAsync();
            return products;
        }
        public async Task<Products?> DeleteProductAsync(int id)
        {
            var isExists = await _db.TblProducts.FirstOrDefaultAsync(x => x.id == id);
            if (isExists == null)
            {
                return null;
            }
            _db.TblProducts.Remove(isExists);   
            await _db.SaveChangesAsync();
            return isExists;
        }

        public async Task<List<Products?>> GetProductsAsync()
        {
           return await _db.TblProducts.ToListAsync();  
           
        }

        public async Task<Products?> GetProductsByIdAsync(int id)
        {
            return _db.TblProducts.FirstOrDefault(x => x.id == id); 
        }

        public async Task<Products?> UpdateProductAsync(int id,Products products)
        {
            var isExists = await _db.TblProducts.FirstOrDefaultAsync(x => x.id == id);

            if(isExists == null)
            {
                return null;    
            }
            isExists.Name = products.Name;
            isExists.Price = products.Price;
            isExists.Category = products.Category;
            isExists.Quantity = products.Quantity;

            await _db.SaveChangesAsync();

            return isExists;    
        }
    }
}
