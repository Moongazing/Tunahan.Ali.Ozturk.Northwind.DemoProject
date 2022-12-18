using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO.Entities.Concrete;

namespace TAO.DataAccess.Test
{
  [TestClass]
  public class SupplierTest
  {
    [TestMethod]
    public void Get_all_returns_all_suppliers()
    {
      EfSupplierDal supplierDal = new EfSupplierDal();

      var result = supplierDal.GetAll();

      Assert.AreEqual(29, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_suppliers()
    {
      EfSupplierDal supplierDal = new EfSupplierDal(); ;

      var result = supplierDal.GetAll(s=>s.Country =="Italy");

      Assert.AreEqual(2, result.Count);
    }

  
  }
}