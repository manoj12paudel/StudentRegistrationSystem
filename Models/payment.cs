using System.ComponentModel.DataAnnotations;

namespace StudentRegestrationSystem.Models
{
    public class payment
    {
        [Key]
        public int Paymentid { get; set; }
        [Required]
        public int Studentid { get; set; }
        [Required]
        public int Courseid { get; set; }
        [Required]
        public string  PaymentAmount { get; set; }
        
      
    }
}
