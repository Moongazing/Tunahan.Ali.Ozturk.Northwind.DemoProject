using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TAO_Core;

namespace TAO.Entities.ComplexTypes
{
  public class OrderDetail:IDto
  {
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public double UnitPrice { get; set; }
    public short Quantity { get; set; }
    public Single Discount { get; set; }
  }
}
