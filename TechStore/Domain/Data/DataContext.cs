using Microsoft.EntityFrameworkCore;
using TechStore.Core.Entities;
using TechStore.Domain.Models;

namespace TechStore.Domain.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
