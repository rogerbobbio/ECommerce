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

        public System.Data.Entity.DbSet<ECommerce.Models.PensionSystem> PensionSystems { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.UserRol> UserRols { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.ProductCategory> ProductCategories { get; set; }
    }
}