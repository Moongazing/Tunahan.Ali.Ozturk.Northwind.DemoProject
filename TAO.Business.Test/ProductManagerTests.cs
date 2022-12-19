using FluentValidation;
using Moq;
using TAO.Business.Concrete;
using TAO.Business.ValidationRules.FluentValidation;
using TAO.DataAccess.Abstract;
using TAO.Entities.Concrete;
using TAO_Core.Aspects.Autofac.Validation;

namespace TAO.Business.Test
{
  [TestClass]
  public class ProductManagerTests
  {
    [ExpectedException(typeof(NullReferenceException))]
    [TestMethod]
    public void Product_validation_check()
    {
      Mock<IProductDal> mock = new Mock<IProductDal>();
      ProductManager productManager = new ProductManager(mock.Object);
      productManager.Add(new Product
      {
        ProductName = "Chai"
      });
    }
    [TestMethod]
    public void Product_business_rules_check()
    {
      Mock<IProductDal> mock = new Mock<IProductDal>();
      ProductManager productManager = new ProductManager(mock.Object);
      productManager.Add(new Product
      {
        ProductID = 108,
        ProductName = "a",
        CategoryID = 3,
        SupplierID = 4,
        QuantityPerUnit = "a",
        ReorderLevel = 4,
        UnitsOnOrder = 4,
        UnitPrice = 20,
        UnitsInStock = 2,
        Discontinued = false
      });
    }

    [TestMethod]
    public void Product_detail_test()
    {
      Mock<IProductDal> mock = new Mock<IProductDal>();
      ProductManager productManager = new ProductManager(mock.Object);
      productManager.GetProductDetails();
    }
  }
}