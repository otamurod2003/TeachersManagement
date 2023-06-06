using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersManagement.Models
{
    public class Pupil
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string? FullName { get; set; }

        [Required]
        [Display(Name = "Class number")]

        public int Old { get; set; }

        [Required]
        [Display(Name = "Learning grade")]
        public Grades? Grade { get; set; }
        public string? TName { get; set; }
       
        /*public virtual IEnumerable<Teacher>? Teachers { get; set; }
*/
    }
}
