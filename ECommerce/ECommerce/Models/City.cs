using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "City")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}