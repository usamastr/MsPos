using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;

namespace MsPos.Models
{
    public class ProductViewModel
    {

       public IEnumerable<Product> Product { get; set; }
       public IEnumerable<Invoice> Invoice { get; set; }


    }
}
