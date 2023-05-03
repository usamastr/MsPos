using System.ComponentModel.DataAnnotations;

namespace MsPos.Models
{
    public class Doctor
    {
        [Key]
        public Int64 DoctorId { get; set; }
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
        public string Qualification { get; set; }       
        public string Speciality { get; set; }       
        public Boolean Status { get; set; }
        public string LicenceNumber { get; set; }

       
        

    }
}
