using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsPos.Models
{
    public class Invoice
    {

        [Key]
        public Int64 InvoiceId { get; set; }
        [DisplayName("Invoice Number")]
        public Int64 InvoiceNumber { get; set; }
        public int? CustomerId { get; set; }       
        [DisplayName("Customer Name")]
        public string? CustomerName { get; set; }
        [Required]
        [DisplayName("Sale Price")]
        public decimal SalePrice  { get; set; }
        [Required]
        [DisplayName("Purchase Price")]
        public decimal PurchasePrice { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Today;
        [DisplayName("Total Amount")]
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        [DisplayName("Payment Method")]
        public string PaymentMethod { get; set; }   
        public int Status { get; set; }
        //[ForeignKey("InvoiceDetail")]
        //public Int64 InvoiceDetailId { get; set; }



    }
}
