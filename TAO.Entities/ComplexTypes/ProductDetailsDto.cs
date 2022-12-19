using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Entities.Concrete;
using TAO_Core;

namespace TAO.Entities.ComplexTypes
{
  public class ProductDetailsDto:IDto
  {
    public Product product { get; set; }
    public string CategoryName { get; set; }
    public string SupplierName { get; set; }
  }
}
