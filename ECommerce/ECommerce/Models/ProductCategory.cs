using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Product Category")]
        [Index("ProductCategory_CompanyId_Description_Index", 2, IsUnique = true)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Index("ProductCategory_CompanyId_Description_Index", 1, IsUnique = true)]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}