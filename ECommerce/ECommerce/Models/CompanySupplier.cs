using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class CompanySupplier
    {
        [Key]
        public int CompanyCustomerId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}