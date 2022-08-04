using System.ComponentModel.DataAnnotations;

namespace MsPos.Models
{
    public class Product
    {

        [Key]
        public Int64 ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int SalePrice  { get; set; }
        [Required]
        public int PurchasePrice { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; }
        public string Packing { get; set; }
        public string Type { get; set; }
        public string Description  { get; set; }   
        public DateTime ExpiryDate { get; set; }
        public string Category { get; set; }
        public int Discount { get; set; }

    }
}
