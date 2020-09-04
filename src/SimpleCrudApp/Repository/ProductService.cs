using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.DataAccess;
using SimpleCrudApp.Models;

namespace SimpleCrudApp.Repository
{
    public class ProductService : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            if (model is null) throw new ArgumentNullException(message:"The product entered is invalid", null);
            await _dbContext.Product.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<ProductModel> DeleteProduct(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(message: "The product is invalid or has been deleted!", null);
            }
            var product = await _dbContext.Product.FindAsync(id);
            _dbContext.Product.Remove(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<ProductModel>> GetProduct()
        {
           return await _dbContext.Product.ToListAsync();
        }

        public ProductModel GetProductUpdateId(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(message: "Not a valid product or has been deleted!", null);
            }
            var product = _dbContext.Product.FirstOrDefault(m => m.Id == id);
            return product;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            if (model is null) throw new ArgumentNullException(message: "Check product details or product doesn't exist!", null);

            _dbContext.Product.Update(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }
        
    }
}
