using Microsoft.EntityFrameworkCore;
using TechStore.Core.Entities;

namespace TechStore.Domain.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Category> Products { get; set; }
    }
}
