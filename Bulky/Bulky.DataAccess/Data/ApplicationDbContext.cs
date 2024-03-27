using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
             new Category { CategoryId = 1, Name = "Máy Lạnh", DisplayOrder = 1 },
             new Category { CategoryId = 2, Name = "Điện Thoại", DisplayOrder = 2 },
             new Category { CategoryId = 3, Name = "Gia Dụng", DisplayOrder = 3 }
            );
        }
    }
}
