using System.ComponentModel.DataAnnotations;

namespace MsPos.Models
{
    public class Customer
    {
        [Key]
        public Int64 CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime LastModifiedDate { get; set; }= DateTime.Now;
        public string Email { get; set; }
        
        public Boolean Status { get; set; }
        public string Phone { get; set; }  
        

    }
}
