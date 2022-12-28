using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Entities.Concrete;
using TAO_Core;

namespace TAO.Entities.ComplexTypes
{
  public class TerritoryDetailsDto:IDto
  {
    public Territory Territory { get; set; }
    public string RegionDescription { get; set; }

  }
}
