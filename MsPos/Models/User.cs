using System.ComponentModel.DataAnnotations;

namespace MsPos.Models
{
    public class User
    {
        [Key]
        public Int64 Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime LastModifiedDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public Boolean IsAdmin { get; set; }
        

    }
}
