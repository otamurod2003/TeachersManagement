using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Display(Name ="First name")]
        [Required(ErrorMessage = "First name is not required...")]
        [MaxLength(50, ErrorMessage = "First name must be less than 50 characters long...")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is not filled...")]
        [MaxLength(50, ErrorMessage = "Last name must be less than 50 characters long...")]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage ="Date of birth not filled...")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Specialty")]
        [Required(ErrorMessage= "Field of specialization is not filled...")]
        public Specialty? Specialty { get; set; }

        [Display(Name = "Experience (per year)")]
        [Required(ErrorMessage ="Experience not filled")]
        [Range(0.00,1000000000.00)]
        public float  Experience { get; set; }

        /*[NotMapped]
        public int? PupilId { get; set; }
        public virtual IEnumerable<Pupil>? Pupils { get; set; }*/
    }
}
