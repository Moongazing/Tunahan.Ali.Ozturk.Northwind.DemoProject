using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO_Core.Entities;

namespace TAO.Entities.Concrete
{
  public class Territory:IEntity
  {
    public string TerritoryID { get; set; }
    public string TerritoryDescription{ get; set; }
    public int RegionID { get; set; }
  }
}
