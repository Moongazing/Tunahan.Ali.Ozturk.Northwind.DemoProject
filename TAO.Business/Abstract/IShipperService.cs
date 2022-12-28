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
  public interface IShipperService
  {
    IResult Add(Shipper shipper);
    IResult Delete(Shipper shipper);
    IResult Update(Shipper shipper);
    IDataResult<List<Shipper>> GetAll();
    IDataResult<List<Shipper>> GetById(int shipperId);
    IDataResult<List<Shipper>> GetByCompanyName(string companyName);
    IDataResult<List<Shipper>> GetByPhoneNumber(string phoneNumber);




  }
}
