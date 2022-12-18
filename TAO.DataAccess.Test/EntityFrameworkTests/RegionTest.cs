using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO.Entities.Concrete;

namespace TAO.DataAccess.Test
{
  [TestClass]
  public class RegionTest
  {
    [TestMethod]
    public void Get_all_returns_all_regions()
    {
      EfRegionDal regionDal = new EfRegionDal();

      var result = regionDal.GetAll();

      Assert.AreEqual(4, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_regions()
    {
      EfRegionDal regionDal = new EfRegionDal();

      var result = regionDal.GetAll(r=>r.RegionDescription== "Western");

      Assert.AreEqual(1, result.Count);
    }

  
  }
}