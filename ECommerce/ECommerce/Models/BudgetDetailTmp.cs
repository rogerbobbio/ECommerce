using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class BudgetDetailTmp
    {
        [Key]
        public int BudgetDetailTmpId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(256, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(4, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        public string CategoryCode { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(4, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        public string SubcategoryCode { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Categoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Sub Categoria")]
        public string Subcategory { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(250, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(5, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Unidad")]
        public string Unity { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, double.MaxValue, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Metrado")]
        public double Metered { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, double.MaxValue, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Precio unitario")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, double.MaxValue, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Precio parcial")]
        public decimal PartialPrice { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Estado/Commentarios")]
        public string Remarks { get; set; }
    }
}