using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class ProjectState
    {
        [Key]
        public int ProjectStateId { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Project State")]
        [Index("ProjectState_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}