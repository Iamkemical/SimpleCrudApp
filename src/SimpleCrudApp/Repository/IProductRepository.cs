using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleCrudApp.Models;

namespace SimpleCrudApp.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetProduct();
        Task<ProductModel> CreateProduct(ProductModel model);
        ProductModel GetProductUpdateId(Guid id);
        Task<ProductModel> UpdateProduct(ProductModel model);
        Task<ProductModel> DeleteProduct(Guid id);
    }
}
