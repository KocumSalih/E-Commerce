using Microsoft.EntityFrameworkCore;

namespace ECommerceProjectWithWebAPI.DAL.Concrete.Contexts
{
    using DAL.Concrete.EntityFramework.Mapping;
    using Entities.Concrete;

    public class ECommerceProjectWithWebAPIContext : DbContext
    {
        public ECommerceProjectWithWebAPIContext(DbContextOptions<ECommerceProjectWithWebAPIContext> options) : base(options)
        {
        }

        public ECommerceProjectWithWebAPIContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-DPKMFQT\\S2019; Database=ECommerceProjectWithWebAPI; uid=sa; pwd=1;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        public virtual DbSet<User> Users {get; set;}
    }
}
