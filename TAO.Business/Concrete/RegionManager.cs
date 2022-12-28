using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Business.Abstract;
using TAO.Business.Constans;
using TAO.Business.ValidationRules.FluentValidation;
using TAO.DataAccess.Abstract;
using TAO.Entities.Concrete;
using TAO_Core.Aspects.Autofac.Caching;
using TAO_Core.Aspects.Autofac.Performance;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.Business.Concrete
{
  public class RegionManager:IRegionService
  {
    private readonly IRegionDal _regionDal;

    public RegionManager(IRegionDal regionDal)
    {
      _regionDal = regionDal;
    }
    [ValidationAspect(typeof(RegionValidator))]
    [PerformanceAspect(10)]
    [CacheRemoveAspect("IRegionService.Get")]
    public IResult Add(Region region)
    {
      _regionDal.Add(region);
      return new SuccessResult(Messages.RegionAdded);
    }
    [ValidationAspect(typeof(RegionValidator))]
    [PerformanceAspect(10)]
    public IResult Delete(Region region)
    {
      _regionDal.Delete(region);
      return new SuccessResult(Messages.RegionDeleted);
    }
    [ValidationAspect(typeof(RegionValidator))]
    [PerformanceAspect(10)]
    public IResult Update(Region region)
    {
      _regionDal.Update(region);
      return new SuccessResult(Messages.RegionUpdated);
    }
    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Region>> GetAll()
    {
      return new SuccessDataResult<List<Region>>(_regionDal.GetAll(),Messages.RegionsListed);
    }
    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Region>> GetById(int regionId)
    {
      return new SuccessDataResult<List<Region>>(_regionDal.GetAll(r => r.RegionID == regionId),Messages.RegionsListedById);
    }
    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Region>> GetByDescription(string description)
    {
      return new SuccessDataResult<List<Region>>(
        _regionDal.GetAll(
          r => r.RegionDescription == description || r.RegionDescription.Contains(description.ToLower())),
        Messages.RegionsListedByDescription);
    }
  }
}
