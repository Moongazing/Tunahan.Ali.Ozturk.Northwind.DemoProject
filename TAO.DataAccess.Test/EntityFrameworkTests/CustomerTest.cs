using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO.Entities.Concrete;

namespace TAO.DataAccess.Test
{
  [TestClass]
  public class CustomerTest
  {
    [TestMethod]
    public void Get_all_returns_all_customers()
    {
      EfCustomerDal customerDal = new EfCustomerDal();

      var result = customerDal.GetAll();

      Assert.AreEqual(91, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_customers()
    {
      EfCustomerDal customerDal = new EfCustomerDal();

      var result = customerDal.GetAll(c => c.Country == "Italy");

      Assert.AreEqual(3, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_customers2()
    {
      EfCustomerDal customerDal = new EfCustomerDal();

      var result = customerDal.GetAll(c => c.Fax == "011-4988261");

      Assert.AreEqual(1, result.Count);
    }


  }
}