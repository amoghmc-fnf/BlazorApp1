using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
    }

    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
