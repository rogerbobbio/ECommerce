using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class UserRol
    {
        [Key]
        public int UserRolId { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "User Rol")]
        [Index("UserRol_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Display(Name = "Jornal Básico (S/.)")]        
        [Required(ErrorMessage = "The field {0} is required")]
        public double BasicJornal { get; set; }

        [Display(Name = "B.U.C. (%)")]
        [Range(0, 100, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Buc { get; set; }

        [Display(Name = "Movilidad Acumulada (S/.)")]        
        [Required(ErrorMessage = "The field {0} is required")]
        public double AccumulatedMobility { get; set; }

        [Display(Name = "Dominical (S/.)")]        
        [Required(ErrorMessage = "The field {0} is required")]
        public double Dominical { get; set; }

        [Display(Name = "Vacaciones (S/.)")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Holidays { get; set; }

        [Display(Name = "CTS (S/.)")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Cts { get; set; }

        [Display(Name = "Gratificación (S/.)")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Reward { get; set; }

        [Display(Name = "Hra. Extra 60% (S/.)")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double HourExtra60 { get; set; }

        [Display(Name = "Hra. Extra 100% (S/.)")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double HourExtra100 { get; set; }

        [Display(Name = "Escolaridad (S/.)")]
        [Required(ErrorMessage = "The field {0} is required")]
        public double Scholarship { get; set; }

        public virtual Company Companies { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}