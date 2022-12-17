using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO.Entities.Concrete;

namespace TAO.DataAccess.Test
{
  [TestClass]
  public class ProductTest
  {
    [TestMethod]
    public void Get_all_returns_all_products()
    {
      EfProductDal productDal = new EfProductDal();

      var result = productDal.GetAll();

      Assert.AreEqual(77, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_products()
    {
      EfProductDal productDal = new EfProductDal();

      var result = productDal.GetAll(P => P.CategoryID == 2);

      Assert.AreEqual(12, result.Count);
    }

   
  }
}