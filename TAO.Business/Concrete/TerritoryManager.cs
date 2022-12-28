using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Business.Abstract;
using TAO.Business.Constans;
using TAO.Business.ValidationRules.FluentValidation;
using TAO.DataAccess.Abstract;
using TAO.Entities.ComplexTypes;
using TAO.Entities.Concrete;
using TAO_Core.Aspects.Autofac.Caching;
using TAO_Core.Aspects.Autofac.Performance;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.Business.Concrete
{
  public class TerritoryManager : ITerritoryService
  {
    private readonly ITerritoryDal _territoryDal;

    public TerritoryManager(ITerritoryDal territoryDal)
    {
      _territoryDal = territoryDal;
    }

    [PerformanceAspect(5)]
    [CacheRemoveAspect("ITerritoryService.Get")]
    [ValidationAspect(typeof(TerritoryValidator))]
    public IResult Add(Territory territory)
    {
      _territoryDal.Add(territory);
      return new SuccessResult(Messages.TerritoryAdded);
    }

    [PerformanceAspect(5)]
    [CacheRemoveAspect("ITerritoryService.Get")]
    public IResult Delete(Territory territory)
    {
      _territoryDal.Delete(territory);
      return new SuccessResult(Messages.TerritoryDeleted);
    }


    [PerformanceAspect(5)]
    [CacheRemoveAspect("ITerritoryService.Get")]
    [ValidationAspect(typeof(TerritoryValidator))]
    public IResult Update(Territory territory)
    {
      _territoryDal.Update(territory);
      return new SuccessResult(Messages.TerritoryUpdated);
    }

    [PerformanceAspect(5)]
    [CacheAspect(60)]
    public IDataResult<List<Territory>> GetAllTerritories()
    {
      return new SuccessDataResult<List<Territory>>(_territoryDal.GetAll(),Messages.TerritoriesListed);
    }

    [PerformanceAspect(5)]
    [CacheAspect(60)]
    public IDataResult<List<Territory>> GetById(string territoryId)
    {
      return new SuccessDataResult<List<Territory>>(_territoryDal.GetAll(t=>t.TerritoryID == territoryId), Messages.TerritoriesListedById);
    }

    [PerformanceAspect(5)]
    [CacheAspect(60)]
    public IDataResult<List<Territory>> GetByDescription(string description)
    {
      return new SuccessDataResult<List<Territory>>(_territoryDal.GetAll(t=>t.TerritoryDescription == description), Messages.TerritoriesListedByDescription);
    }

    [PerformanceAspect(5)]
    [CacheAspect(60)]
    public IDataResult<List<Territory>> GetByRegionId(int regionId)
    {
      return new SuccessDataResult<List<Territory>>(_territoryDal.GetAll(t=>t.RegionID == regionId), Messages.TerritoriesListedByRegionId);
    }

    [PerformanceAspect(5)]
    [CacheAspect(60)]
    public IDataResult<List<TerritoryDetailsDto>> GetTerritoryDetails()
    {
      return new SuccessDataResult<List<TerritoryDetailsDto>>(_territoryDal.GetTerritoryDetails(),Messages.TerritoryDetailsListed);
    }
  }
}
