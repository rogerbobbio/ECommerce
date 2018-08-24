using System.Data.Entity;

namespace ECommerce.Models
{
    public class ECommerceContext : DbContext
    {
        #region Contructor
        public ECommerceContext() : base("DefaultConnection")
        {
            
        }
        #endregion

        public DbSet<Department> Departments { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.City> Cities { get; set; }
    }
}