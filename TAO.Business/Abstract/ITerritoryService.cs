using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Entities.ComplexTypes;
using TAO.Entities.Concrete;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;

namespace TAO.Business.Abstract
{
  public interface ITerritoryService
  {
    IResult Add(Territory territory);
    IResult Delete(Territory territory);
    IResult Update(Territory territory);
    IDataResult<List<Territory>> GetAllTerritories();
    IDataResult<List<Territory>> GetById(string territoryId);
    IDataResult<List<Territory>> GetByDescription(string description);
    IDataResult<List<Territory>> GetByRegionId(int regionId);
    IDataResult<List<TerritoryDetailsDto>> GetTerritoryDetails();

  }
}
