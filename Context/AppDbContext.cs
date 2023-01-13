using EntityFrameworkPagination.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPagination.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
