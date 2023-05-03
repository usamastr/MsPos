using System.ComponentModel.DataAnnotations;

namespace MsPos.Models
{
    public class Patient
    {
        [Key]
        public Int64 PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }=DateTime.Now;
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime LastModifiedDate { get; set; }= DateTime.Now;
        public string Email { get; set; }       
        public Boolean Status { get; set; }

       
        

    }
}
