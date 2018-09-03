using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class OrderState
    {
        [Key]
        public int OrderStateId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Order State")]
        [Index("OrderState_Description_Index", IsUnique = true)]
        public string Description { get; set; }
    }
}