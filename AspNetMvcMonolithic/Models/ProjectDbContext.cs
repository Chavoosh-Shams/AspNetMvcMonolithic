using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcMonolithic.Models
{
    public class ProjectDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=AspNetMvcMonolithicDb;" +
                    "Integrated Security=True;Persist Security Info=False;Trust Server Certificate=True;");
            }
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
