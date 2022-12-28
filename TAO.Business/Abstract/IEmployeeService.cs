using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Entities.Concrete;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;

namespace TAO.Business.Abstract
{
  public interface IEmployeeService
  {
    IResult Add(Employee employee);
    IResult Delete(Employee employee);
    IResult Update(Employee employee);
    IDataResult<List<Employee>> GetAll();
    IDataResult<List<Employee>> GetById(int employeeId);
    IDataResult<List<Employee>> GetByFirstName(string firstName);
    IDataResult<List<Employee>> GetByLastName(string lastName);
    IDataResult<List<Employee>> GetByTitle(string title);
    IDataResult<List<Employee>> GetByTitleOfCourtesy(string titleCourtesy);
    IDataResult<List<Employee>> GetByBirthDate(DateTime birthDate);
    IDataResult<List<Employee>> GetByAge(int age);
    IDataResult<List<Employee>> GetByHireDate(DateTime hireDate);
    IDataResult<List<Employee>> GetByHireYearBiggerThanParameter(int workYear);
    IDataResult<List<Employee>> GetByAddress(string address);
    IDataResult<List<Employee>> GetByCity(string city);
    IDataResult<List<Employee>> GetByRegion(string region);
    IDataResult<List<Employee>> GetByPostalCode(string postalCode);
    IDataResult<List<Employee>> GetByCountry(string country);
    IDataResult<List<Employee>> GetByExtension(string extension);
    IDataResult<List<Employee>> GetByNotes(string notes);
    IDataResult<List<Employee>> GetByReportsTo(int reportsTo);
    IDataResult<List<Employee>> GetByHomePhone(string homePhone);






  }
}
