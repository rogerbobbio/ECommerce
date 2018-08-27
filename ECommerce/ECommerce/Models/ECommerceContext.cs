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

        public System.Data.Entity.DbSet<ECommerce.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.ProjectState> ProjectStates { get; set; }
    }
}