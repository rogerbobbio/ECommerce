using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ECommerce.Models
{
    public class ECommerceContext : DbContext
    {
        #region Contructor
        public ECommerceContext() : base("DefaultConnection")
        {
            
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        public DbSet<Department> Departments { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<ProjectState> ProjectStates { get; set; }

        public DbSet<PensionSystem> PensionSystems { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserRol> UserRols { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Tax> Taxes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.OrderState> OrderStates { get; set; }
    }
}