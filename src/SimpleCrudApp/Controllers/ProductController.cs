using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudApp.Models;
using SimpleCrudApp.Repository;

namespace SimpleCrudApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        //GET - READ
        public async Task<IActionResult> GetProductAsync()
        {
            var product = await _productRepo.GetProduct();
            return View(product);
        }

        //GET - CREATE
        [HttpGet]
        public IActionResult CreateProductAsync()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductAsync(ProductModel model)
        {
            if (!ModelState.IsValid) return View();

            var product = await _productRepo.CreateProduct(model);
            return LocalRedirect("~/Product/GetProduct");

        }

        //GET - EDIT
        [HttpGet]
        public IActionResult UpdateProduct(Guid id)
        {
            var product =_productRepo.GetProductUpdateId(id);
            return View(product);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductAsync(ProductModel model)
        {
            if (!ModelState.IsValid) return View();

            await _productRepo.UpdateProduct(model);
            return LocalRedirect("~/Product/GetProduct");
        }

        //GET - DELETE
        [HttpGet]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productRepo.GetProductUpdateId(id);
            return View(product);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            await _productRepo.DeleteProduct(id);
            return LocalRedirect("~/Product/GetProduct");
        }
    }
}
