using System.ComponentModel.DataAnnotations;
using TeachersManagement.Models;

namespace TeachersManagement.ViewModels
{
    public class PupilCreateViewModel
    {
        public int Id { get; set; }
       
        [Required]
        [Display(Name = "Full Name")]
        [MaxLength(50)]
        public string? FullName { get; set; }

        [Required]
        [Display(Name = "Old")]
        [Range(6 , 25)]
        public int Old { get; set; }

        [Required(ErrorMessage="Learning grade isn't filled...")]
        [Display(Name = "Learning grade")]
        public Grades? Grade { get; set; }


        // [Required]
        public string? TName { get; set; }
    }
}
