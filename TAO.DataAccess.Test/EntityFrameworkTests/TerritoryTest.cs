using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO.Entities.Concrete;

namespace TAO.DataAccess.Test
{
  [TestClass]
  public class TerritoryTest
  {
    [TestMethod]
    public void Get_all_returns_all_territories()
    {
      EfTerritoryDal territoryDal = new EfTerritoryDal();

      var result = territoryDal.GetAll();

      Assert.AreEqual(53, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_territories()
    {
      EfTerritoryDal territoryDal = new EfTerritoryDal();

      var result = territoryDal.GetAll(t=>t.RegionID == 1);

      Assert.AreEqual(19, result.Count);
    }

  
  }
}