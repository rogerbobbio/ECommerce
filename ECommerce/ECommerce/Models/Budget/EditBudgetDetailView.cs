using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class EditBudgetDetailView
    {        
        public int BudgetDetailTmpId { get; set; }
     
        [Display(Name = "Categoria")]
        public string Category { get; set; }

        [Display(Name = "Sub Categoria")]
        public string Subcategory { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

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

        [DataType(DataType.MultilineText)]
        [Display(Name = "Estado/Commentarios")]
        public string Remarks { get; set; }
    }
}