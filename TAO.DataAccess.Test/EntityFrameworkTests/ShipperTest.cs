using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO.Entities.Concrete;

namespace TAO.DataAccess.Test
{
  [TestClass]
  public class ShipperTest
  {
    [TestMethod]
    public void Get_all_returns_all_shippers()
    {
      EfShipperDal shipperDal = new EfShipperDal();

      var result = shipperDal.GetAll();

      Assert.AreEqual(3, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_shippers()
    {
      EfShipperDal shipperDal = new EfShipperDal();

      var result = shipperDal.GetAll(s=>s.CompanyName.Contains("Express"));

      Assert.AreEqual(1, result.Count);
    }
    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_shippers2()
    {
      EfShipperDal shipperDal = new EfShipperDal();

      var result = shipperDal.GetAll(s => s.Phone.Contains("503"));

      Assert.AreEqual(3, result.Count);
    }



  }
}