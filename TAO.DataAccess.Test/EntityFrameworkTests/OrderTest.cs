using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO.Entities.Concrete;

namespace TAO.DataAccess.Test
{
  [TestClass]
  public class OrderTest
  {
    [TestMethod]
    public void Get_all_returns_all_orders()
    {
      EfOrderDal orderDal = new EfOrderDal();

      var result = orderDal.GetAll();

      Assert.AreEqual(830, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_orders()
    {
      EfOrderDal orderDal = new EfOrderDal();

      var result = orderDal.GetAll(o=>o.EmployeeID == 5);

      Assert.AreEqual(42, result.Count);
    }
    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_orders2()
    {
      EfOrderDal orderDal = new EfOrderDal();

      var result = orderDal.GetAll(o => o.ShipRegion == "RJ");

      Assert.AreEqual(34, result.Count);
    }
    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_orders3()
    {
      EfOrderDal orderDal = new EfOrderDal();

      var result = orderDal.GetAll(o => o.ShipCountry == "Italy");

      Assert.AreEqual(28, result.Count);
    }

  }
}