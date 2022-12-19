using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Entities.Concrete;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;

namespace TAO.Business.Abstract
{
  public interface IRegionService
  {
    IResult Add(Region region);
    IResult Delete(Region region );
    IResult Update(Region region);
    IDataResult<List<Region>> GetAll();
    IDataResult<List<Region>> GetById(int regionId);
    IDataResult<List<Region>> GetByDescription(string description);
  }
}
