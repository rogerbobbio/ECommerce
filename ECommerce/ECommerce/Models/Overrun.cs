using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Overrun
    {
        [Key]
        public int OverrunId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(10, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Codigo de Sobrecosto")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, double.MaxValue, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Total Butget")]
        public decimal TotalButget { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Tipo de sobrecosto")]
        public string Type { get; set; }

        [DataType(DataType.Url)]
        public string Document { get; set; }

        [NotMapped]
        [Display(Name = "Documento")]
        public HttpPostedFileBase DocFile { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        public virtual Project Project { get; set; }
        public virtual Company Company { get; set; }
    }
}