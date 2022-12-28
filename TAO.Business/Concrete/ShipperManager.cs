using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Business.Abstract;
using TAO.Business.Constans;
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
  public class ShipperManager:IShipperService
  {
    private readonly IShipperDal _shipperDal;

    public ShipperManager(IShipperDal shipperDal)
    {
      _shipperDal = shipperDal;
    }

    [ValidationAspect(typeof(Shipper))]
    [PerformanceAspect(5)]
    [CacheRemoveAspect("IShipperService.Get")]
    public IResult Add(Shipper shipper)
    {
      _shipperDal.Add(shipper);
      return new SuccessResult(Messages.ShipperAdded);
    }

    [PerformanceAspect(5)]
    [CacheRemoveAspect("IShipperService.Get")]
    public IResult Delete(Shipper shipper)
    {
      _shipperDal.Delete(shipper);
      return new SuccessResult(Messages.ShipperDeleted);
    }

    [ValidationAspect(typeof(Shipper))]
    [PerformanceAspect(5)]
    [CacheRemoveAspect("IShipperService.Get")]
    public IResult Update(Shipper shipper)
    {
      _shipperDal.Update(shipper);
      return new SuccessResult(Messages.ShipperUpdated);
    }

    [CacheAspect(60)]
    [PerformanceAspect(5)]
    public IDataResult<List<Shipper>> GetAll()
    {
      return new SuccessDataResult<List<Shipper>>(_shipperDal.GetAll(), Messages.ShippersListed);
    }

    [CacheAspect(60)]
    [PerformanceAspect(5)]
    public IDataResult<List<Shipper>> GetById(int shipperId)
    {
      return new SuccessDataResult<List<Shipper>>(_shipperDal.GetAll(s => s.ShipperID == shipperId),
        Messages.ShippersListedById);
    }

    [CacheAspect(60)]
    [PerformanceAspect(5)]
    public IDataResult<List<Shipper>> GetByCompanyName(string companyName)
    {
      return new SuccessDataResult<List<Shipper>>(
        _shipperDal.GetAll(s => s.CompanyName == companyName || s.CompanyName.Contains(companyName.ToLower())),
        Messages.ShippersListedByCompanyName);
    }

    [CacheAspect(60)]
    [PerformanceAspect(5)]
    public IDataResult<List<Shipper>> GetByPhoneNumber(string phoneNumber)
    {
      return new SuccessDataResult<List<Shipper>>(
        _shipperDal.GetAll(s => s.Phone == phoneNumber || s.Phone.Contains(phoneNumber)),
        Messages.ShippersListedByPhoneNumber);
    }
  }
}
