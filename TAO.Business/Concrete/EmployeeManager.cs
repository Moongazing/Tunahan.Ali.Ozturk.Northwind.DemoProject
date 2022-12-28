using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Principal;
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
  public class EmployeeManager : IEmployeeService
  {
    private readonly IEmployeeDal _employeeDal;


    #region BusinessRules



    #endregion
    public EmployeeManager(IEmployeeDal employeeDal)
    {
      _employeeDal = employeeDal;
    }
    [PerformanceAspect(10)]
    [ValidationAspect(typeof(EmployeeValidator))]
    [CacheRemoveAspect("IEmployeeService.Get")]
    public IResult Add(Employee employee)
    {
      _employeeDal.Add(employee);
      return new SuccessResult(Messages.EmployeeAdded);
    }

    [PerformanceAspect(10)]
    [CacheRemoveAspect("IEmployeeService.Get")]
    public IResult Delete(Employee employee)
    {
      _employeeDal.Delete(employee);
      return new SuccessResult(Messages.EmployeeDeleted);
    }

    [PerformanceAspect(10)]
    [ValidationAspect(typeof(EmployeeValidator))]
    [CacheRemoveAspect("IEmployeeService.Get")]
    public IResult Update(Employee employee)
    {
      _employeeDal.Update(employee);
      return new SuccessResult(Messages.EmployeeUpdated);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetAll()
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(), Messages.EmployeesListed);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetById(int employeeId)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.EmployeeID == employeeId),Messages.EmployeesListedById);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByFirstName(string firstName)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e =>
        e.FirstName == firstName || e.FirstName.Contains(firstName.ToLower())),Messages.EmployeesListedByFirstName);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByLastName(string lastName)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e=>e.LastName == lastName || e.LastName.Contains(lastName.ToLower())),Messages.EmployeesListedByLastName);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByTitle(string title)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e=>e.Title == title || e.Title.Contains(title.ToLower())),Messages.EmployeesListedByTitle);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByTitleOfCourtesy(string titleCourtesy)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.TitleOfCourtesy == titleCourtesy || e.TitleOfCourtesy.Contains(titleCourtesy)),Messages.EmployeesListedByTitleOfCourtesy);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByBirthDate(DateTime birthDate)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.BirthDate == birthDate), Messages.EmployeesListedByBirthDate);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByAge(int age)
    {
      throw new NotImplementedException();
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByHireDate(DateTime hireDate)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.HireDate == hireDate), Messages.EmployeesListedByHireDate);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByHireYearBiggerThanParameter(int workYear)
    {
      throw new NotImplementedException();
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByAddress(string address)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.Address == address || e.Address.Contains(address)), Messages.EmployeesListedByAddress);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByCity(string city)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.City == city || e.Country.Contains(city)), Messages.EmployeesListedByCity);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByRegion(string region)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.Region == region || e.Region.Contains(region)), Messages.EmployeesListedByRegion);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByPostalCode(string postalCode)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.PostalCode == postalCode || e.PostalCode.Contains(postalCode)), Messages.EmployeesListedByPostalCode);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByCountry(string country)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e=>e.Country == country || e.Country.Contains(country)),Messages.EmployeesListedByContry);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByExtension(string extension)
    {

      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.Extension == extension || e.Extension.Contains(extension)), Messages.EmployeesListedByExtensions);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByNotes(string notes)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.Notes == notes || e.Notes.Contains(notes)), Messages.EmployeesListedByNotes);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByReportsTo(int reportsTo)
    {
      return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e=>e.ReportsTo == reportsTo),Messages.EmployeesListedByManager);
    }

    [CacheAspect(60)]
    [PerformanceAspect(10)]
    public IDataResult<List<Employee>> GetByHomePhone(string homePhone)
    {
      return new SuccessDataResult<List<Employee>>(
        _employeeDal.GetAll(e => e.HomePhone == homePhone || e.HomePhone.Contains(homePhone)),
        Messages.EmployeesListedByHomePhone);
    }
  }
}
