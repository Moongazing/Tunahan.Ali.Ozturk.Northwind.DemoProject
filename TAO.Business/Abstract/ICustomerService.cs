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
  public interface ICustomerService
  {
    IResult Add(Customer customer);
    IResult Delete(Customer customer);
    IResult Update(Customer customer);
    IDataResult<List<Customer>> GetAllCustomers();
    IDataResult<List<Customer>> GetByCustomerId(string customerId);
    IDataResult<List<Customer>> GetByCompanyName(string companyName);
    IDataResult<List<Customer>> GetByContactName(string contactName);
    IDataResult<List<Customer>> GetByContactTitle(string contactTitle);
    IDataResult<List<Customer>> GetByAddress(string address);
    IDataResult<List<Customer>> GetByCity(string city);
    IDataResult<List<Customer>> GetByRegion(string region);
    IDataResult<List<Customer>> GetByPostalCode(string postalCode);
    IDataResult<List<Customer>> GetByCountry(string country);
    IDataResult<List<Customer>> GetByPhoneNumber(string phoneNumber);
    IDataResult<List<Customer>> GetByFaxNumber(string faxNumber);



  }
}
