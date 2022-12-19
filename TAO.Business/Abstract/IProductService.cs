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
  public interface IProductService
  {
    IResult Add(Product product);
    IResult Delete(Product product);
    IResult Update(Product product);
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> GetByProductId(int productId);
    IDataResult<List<Product>> GetByProductName(string productName);
    IDataResult<List<Product>> GetBySupplierId(int supplierId);
    IDataResult<List<Product>> GetByCategoryId(int categoryId);
    IDataResult<List<Product>> GetByUnitPrice(decimal unitPrice);
    IDataResult<List<Product>> GetByMaxUnitPrice(decimal maxUnitPrice, decimal minUnitPrice);
    IDataResult<List<Product>> GetByUnitsInStock(short unitsInStock);
    IDataResult<List<Product>> GetByUnitStockLessThanParameter(short unitsInStock);
    IDataResult<List<Product>> GetByUnitsOnOrder(short unitsOnOrder);
    IDataResult<List<Product>> GetByUnitsOnOrderLessThanParameter(short unitsOnOrder);
    IDataResult<List<Product>> GetByReoderLevel(short reorderLevel);
    IDataResult<List<Product>> GetByDiscontinued(bool isDiscntinued);










  }
}
