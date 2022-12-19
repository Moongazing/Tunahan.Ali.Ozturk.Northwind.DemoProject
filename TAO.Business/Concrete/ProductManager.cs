using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Business.Abstract;
using TAO.Business.Constans;
using TAO.DataAccess.Abstract;
using TAO.Entities.Concrete;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.Business.Concrete
{
  public class ProductManager:IProductService
  {
    private IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
      _productDal = productDal;
    }

    #region BusinessRules

    

    #endregion

    public IResult Add(Product product)
    {
      _productDal.Add(product);
      return new SuccessResult(Messages.ProductAdded);
    }

    public IResult Delete(Product product)
    {
      _productDal.Delete(product);
      return new SuccessResult(Messages.ProductDeleted);
    }

    public IResult Update(Product product)
    {
      _productDal.Update(product);
      return new SuccessResult(Messages.ProductUpdated);
    }

    public IDataResult<List<Product>> GetAll()
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
    }

    public IDataResult<List<Product>> GetByProductId(int productId)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.ProductID == productId), Messages.ProductListedByProductId);
    }

    public IDataResult<List<Product>> GetByProductName(string productName)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.ProductName == productName || p.ProductName.Contains(productName.ToLower())), Messages.ProductListedByProductName);
    }

    public IDataResult<List<Product>> GetBySupplierId(int supplierId)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.SupplierID == supplierId),
        Messages.ProductListedBySupplierId);
    }

    public IDataResult<List<Product>> GetByCategoryId(int categoryId)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == categoryId),
        Messages.ProductListedByCategoryId);
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal unitPrice)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice == unitPrice),
        Messages.ProductListedByUnitPrice);
    }

    public IDataResult<List<Product>> GetByMaxUnitPrice(decimal maxUnitPrice, decimal minUnitPrice)
    {
      return new SuccessDataResult<List<Product>>(
        _productDal.GetAll(p => p.UnitPrice >= minUnitPrice && p.UnitPrice <= maxUnitPrice),
        Messages.ProductListedByMaxAndMinUnitePrice);
    }

    public IDataResult<List<Product>> GetByUnitsInStock(short unitsInStock)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitsInStock == unitsInStock),
        Messages.ProductListedByUnitsInStock);
    }

    public IDataResult<List<Product>> GetByUnitStockLessThanParameter(short unitsInStock)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitsInStock < unitsInStock),
        Messages.ProductListedByUnitStockLessThanParameter);
    }

    public IDataResult<List<Product>> GetByUnitsOnOrder(short unitsOnOrder)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitsOnOrder == unitsOnOrder),
        Messages.ProductListedByUnitOnOrder);
    }

    public IDataResult<List<Product>> GetByUnitsOnOrderLessThanParameter(short unitsOnOrder)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitsOnOrder < unitsOnOrder),
        Messages.ProductListedByUnitsOnOrderLessThanParameter);
    }

    public IDataResult<List<Product>> GetByReoderLevel(short reorderLevel)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ReorderLevel == reorderLevel),
        Messages.ProductListedByReorderLevel);
    }

    public IDataResult<List<Product>> GetByDiscontinued(bool isDiscntinued)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.Discontinued == isDiscntinued),
        Messages.ProductListedByDiscontinued);
    }
  }
}
