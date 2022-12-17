using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Entities.Concrete;
using TAO_Core.DataAccess;

namespace TAO.DataAccess.Abstract
{
  public interface ICategoryDal:IEntityRepository<Category>
  {
  }
}
