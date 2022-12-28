using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.DataAccess.Abstract;
using TAO.Entities.ComplexTypes;
using TAO.Entities.Concrete;
using TAO_Core.DataAccess.EntityFramework;

namespace TAO.DataAccess.Concrete.EntityFramework.Dals
{
  public class EfTerritoryDal : EfEntityRepositoryBase<Territory, NorthwindContext>, ITerritoryDal
  {
    public List<TerritoryDetailsDto> GetTerritoryDetails()
    {
      using (var context = new NorthwindContext())
      {
        var result = from terriorty in context.Territories
          join region in context.Region on terriorty.RegionID equals region.RegionID
          select new TerritoryDetailsDto
          {
            Territory = terriorty,
            RegionDescription = region.RegionDescription

          };
        return result.ToList();

      }
    }
    
  }
}
