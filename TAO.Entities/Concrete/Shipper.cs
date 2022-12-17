using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO_Core.Entities;

namespace TAO.Entities.Concrete
{
  public class Shipper:IEntity
  {
    public int ShipperID { get; set; }
    public string CompanyName { get; set; }
    public int Phone { get; set; }
  }
}
