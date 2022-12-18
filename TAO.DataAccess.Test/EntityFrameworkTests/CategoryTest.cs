using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO.Entities.Concrete;

namespace TAO.DataAccess.Test
{
  [TestClass]
  public class CategoryTest
  {
    [TestMethod]
    public void Get_all_returns_all_categories()
    {
      EfCategoryDal categoryDal = new EfCategoryDal();

      var result = categoryDal.GetAll();

      Assert.AreEqual(8, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_categories()
    {
      EfCategoryDal categoryDal = new EfCategoryDal();

      var result = categoryDal.GetAll(c => c.CategoryName.Contains("Co"));

      Assert.AreEqual(2, result.Count);
    }

  
  }
}