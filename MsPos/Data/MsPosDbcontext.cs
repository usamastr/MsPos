using Microsoft.EntityFrameworkCore;
using MsPos.Models;

namespace MsPos.Data
{
    public class MsPosDbcontext :DbContext
    {
        public MsPosDbcontext(DbContextOptions<MsPosDbcontext>options):base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Patient> Patient { get; set; }


    }
}
