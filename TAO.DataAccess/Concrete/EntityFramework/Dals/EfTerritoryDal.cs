using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.DataAccess.Abstract;
using TAO.Entities.Concrete;
using TAO_Core.DataAccess.EntityFramework;

namespace TAO.DataAccess.Concrete.EntityFramework.Dals
{
  public class EfTerritoryDal:EfEntityRepositoryBase<Territory,NorthwindContext>,ITerritoryDal
  {
  }
}
