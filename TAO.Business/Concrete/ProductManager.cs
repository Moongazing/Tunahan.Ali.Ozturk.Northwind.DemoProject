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
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.Business.Concrete
{
  public class ProductManager : IProductService
  {
    private readonly IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
      _productDal = productDal;
    }

    #region BusinessRules

    private IResult CheckIfProductNameExists(string productName)
    {
      var result = _productDal.GetAll(p => p.ProductName == productName).Count;
      if (result > 0)
      {
        return new ErrorResult(Messages.ProductNameAlreadyExists);
      }

      return new SuccessResult();
    }

    private IResult CheckIfDiscontiuned(bool isDiscontiuned)
    {
      var result = _productDal.GetAll(p => p.Discontinued == isDiscontiuned);
      if (isDiscontiuned == false)
      {
        throw new Exception("A");
      }

      return new SuccessResult();
    }


    #endregion


    [PerformanceAspect(10)]
    [CacheRemoveAspect("IProductService.Get")]
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
      var result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                                                  CheckIfDiscontiuned(product.Discontinued));
      if (result != null)
      {
        return result;
      }
      _productDal.Add(product);
      return new SuccessResult(Messages.ProductAdded);
    }
    [PerformanceAspect(5)]
    public IResult Delete(Product product)
    {
      _productDal.Delete(product);
      return new SuccessResult(Messages.ProductDeleted);
    }
    [PerformanceAspect(10)]
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Update(Product product)
    {
      _productDal.Update(product);
      return new SuccessResult(Messages.ProductUpdated);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetAll()
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByProductId(int productId)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ProductID == productId), Messages.ProductListedByProductId);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByProductName(string productName)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ProductName == productName || p.ProductName.Contains(productName.ToLower())), Messages.ProductListedByProductName);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetBySupplierId(int supplierId)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.SupplierID == supplierId),
        Messages.ProductListedBySupplierId);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByCategoryId(int categoryId)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == categoryId),
        Messages.ProductListedByCategoryId);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByUnitPrice(decimal unitPrice)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice == unitPrice),
        Messages.ProductListedByUnitPrice);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByMaxUnitPrice(decimal maxUnitPrice, decimal minUnitPrice)
    {
      return new SuccessDataResult<List<Product>>(
        _productDal.GetAll(p => p.UnitPrice >= minUnitPrice && p.UnitPrice <= maxUnitPrice),
        Messages.ProductListedByMaxAndMinUnitePrice);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByUnitsInStock(short unitsInStock)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitsInStock == unitsInStock),
        Messages.ProductListedByUnitsInStock);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByUnitStockLessThanParameter(short unitsInStock)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitsInStock < unitsInStock),
        Messages.ProductListedByUnitStockLessThanParameter);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByUnitsOnOrder(short unitsOnOrder)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitsOnOrder == unitsOnOrder),
        Messages.ProductListedByUnitOnOrder);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByUnitsOnOrderLessThanParameter(short unitsOnOrder)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitsOnOrder < unitsOnOrder),
        Messages.ProductListedByUnitsOnOrderLessThanParameter);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByReoderLevel(short reorderLevel)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ReorderLevel == reorderLevel),
        Messages.ProductListedByReorderLevel);
    }
    [PerformanceAspect(10)]
    [CacheAspect]
    public IDataResult<List<Product>> GetByDiscontinued(bool isDiscontinued)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.Discontinued == isDiscontinued),
        Messages.ProductListedByDiscontinued);
    }
    [CacheAspect]
    public IDataResult<List<ProductDetailsDto>> GetProductDetails()
    {
      return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails());
    }
  }
}
