using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsPos.Models
{
    public class InvoiceDetail
    {

        [Key]
        public Int64 InvoiceDetailId { get; set; }
        [ForeignKey("Invoice")]
        public Int64 InvoiceId { get; set; }
        public Int64 ProductId { get; set; }       
        [DisplayName("Unit Price")]
        public decimal UnitPrice  { get; set; }             
        public int Quantity { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [DisplayName("Modified Date")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;      
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public int Status { get; set; }



    }
}
