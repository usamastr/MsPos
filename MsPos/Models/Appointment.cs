using System.ComponentModel.DataAnnotations;

namespace MsPos.Models
{
    public class Appointment
    {
        [Key]
        public Int64 AppointmentId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string DoctorId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public int Token { get; set; }
        public int Fee { get; set; }
        public int Payment { get; set; }
        public int Balance { get; set; }


    }
}
