using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MsPos.Models
{
    public class Product
    {

        [Key]
        public Int64 ProductId { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Sale Price")]
        public int SalePrice  { get; set; }
        [Required]
        [DisplayName("Purchase Price")]
        public int PurchasePrice { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public string Packing { get; set; }
        public string Type { get; set; }
        public string Description  { get; set; }
        [DisplayName("Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        public string Category { get; set; }
        public int Discount { get; set; }

    }
}
