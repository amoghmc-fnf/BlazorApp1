using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext context;
        public ProductController(ProductDbContext context)
        {
            this.context = context;
        }

        [HttpGet("AllProducts")]
        public List<Product> GetAllProducts() => context.Products.ToList();

        [HttpGet("AllProducts/{id}")]
        public Product GetProductById(int id)
        {
            var found = context.Products.FirstOrDefault(p => p.productId == id);
            if (found == null)
                throw new Exception("Product not found!");

            return found;
        }

        [HttpPost]
        public string AddProduct(Product product)
        {
            product.productId = 0;
            context.Products.Add(product);
            context.SaveChanges();
            return "Product added successfully!";
        }

        [HttpPut]
        public string UpdateProduct(Product product)
        {
            var found = context.Products.FirstOrDefault(p => p.productId == product.productId);
            if (found == null)
                throw new Exception("Product not found!");
            
            found.productName = product.productName;
            found.productPrice = product.productPrice;
            context.SaveChanges();
            return "Product updated successfully!";
        }

        [HttpDelete]
        public string DeleteProduct(int id)
        {
            var found = context.Products.FirstOrDefault(p => p.productId == id);
            if (found == null)
                throw new Exception("Product not found!");

            context.Products.Remove(found);
            context.SaveChanges();
            return "Product deleted successfully!";
        }
    }
}
