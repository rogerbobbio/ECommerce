using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class PensionSystem
    {
        [Key]
        public int PensionSystemId { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Pension System")]
        [Index("PensionSystem_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [Display(Name = "Comisión (%)")]
        [Range(0, 100, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Commission { get; set; }

        [Display(Name = "Prima (%)")]
        [Range(0, 100, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Bonus { get; set; }

        [Display(Name = "Aporte (%)")]
        [Range(0, 100, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Input { get; set; }

        [Display(Name = "Total (%)")]
        [Range(0, 100, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Total { get; set; }

        [Display(Name = "Tope")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Top { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}