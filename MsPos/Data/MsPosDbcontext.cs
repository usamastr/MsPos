using Microsoft.EntityFrameworkCore;
using MsPos.Models;

namespace MsPos.Data
{
    public class MsPosDbcontext :DbContext
    {
        public MsPosDbcontext(DbContextOptions<MsPosDbcontext>options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }


    }
}
