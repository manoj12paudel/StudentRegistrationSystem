using System.ComponentModel.DataAnnotations;

namespace StudentRegestrationSystem.Models
{
    public class record
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstMidName { get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
}
