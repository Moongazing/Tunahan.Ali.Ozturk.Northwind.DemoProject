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
  public class CustomerManager : ICustomerService
  {
    private ICustomerDal _customerDal;
    public CustomerManager(ICustomerDal customerDal)
    {
      _customerDal = customerDal;
    }
    [PerformanceAspect(10)]
    [ValidationAspect(typeof(CustomerValidator))]
    [CacheRemoveAspect("ICustomerService.Get")]
    public IResult Add(Customer customer)
    {
      _customerDal.Add(customer);
      return new SuccessResult(Messages.CustomerAdded);
    }
    [PerformanceAspect(5)]
    public IResult Delete(Customer customer)
    {
      _customerDal.Delete(customer);
      return new SuccessResult(Messages.CustomerDeleted);
    }
    [PerformanceAspect(5)]
    [ValidationAspect(typeof(CustomerValidator))]
    public IResult Update(Customer customer)
    {
      _customerDal.Update(customer);
      return new SuccessResult(Messages.CustomerUpdated);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetAllCustomers()
    {
      return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByCustomerId(string customerId)
    {
      return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c =>
        c.CustomerID == customerId || c.CustomerID.Contains(customerId.ToUpper())), Messages.CustomersListedById);
    }
    [CacheAspect]
    [PerformanceAspect(10)]
    public IDataResult<List<Customer>> GetByCompanyName(string companyName)
    {
      return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c =>
        c.CompanyName == companyName || c.CompanyName.Contains(companyName.ToLower())), Messages.CustomersListedByCompanyName);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByContactName(string contactName)
    {
      return new SuccessDataResult<List<Customer>>(
        _customerDal.GetAll(c => c.ContactName == contactName || c.ContactName.Contains(contactName.ToLower())),
        Messages.CustomersListedByContactName);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByContactTitle(string contactTitle)
    {
      return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.ContactTitle == contactTitle || c.ContactTitle.Contains(contactTitle.ToLower())), Messages.CustomersListedByContactTitle);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByAddress(string address)
    {
      return new SuccessDataResult<List<Customer>>(
        _customerDal.GetAll(c => c.Address == address || c.Address.Contains(address.ToLower())),
        Messages.CustomersListedByAddress);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByCity(string city)
    {
      return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.City == city || c.City.Contains(city.ToLower())), Messages.CustomersListedByCity);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByRegion(string region)
    {
      return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.Region == region || c.Region.Contains(region.ToLower())), Messages.CustomersListedByRegion);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByPostalCode(string postalCode)
    {
      return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.PostalCode == postalCode || c.PostalCode.Contains(postalCode.ToLower())), Messages.CustomersListedByPostalCode);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByCountry(string country)
    {
      return new SuccessDataResult<List<Customer>>(
        _customerDal.GetAll(c => c.Country == country || c.Country.Contains(country.ToLower())),
        Messages.CustomersListedByCountry);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByPhoneNumber(string phoneNumber)
    {
      return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.Phone == phoneNumber || c.Phone.Contains(phoneNumber)), Messages.CustomersListedByPhoneNumber);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Customer>> GetByFaxNumber(string faxNumber)
    {
      return new SuccessDataResult<List<Customer>>(
        _customerDal.GetAll(c => c.Fax == faxNumber || c.Fax.Contains(faxNumber)), Messages.CustomersListedByFaxNumber);
    }
  }
}
