using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO.Entities.Concrete;

namespace TAO.DataAccess.Test
{
  [TestClass]
  public class EmployeeTest
  {
    [TestMethod]
    public void Get_all_returns_all_employees()
    {
      EfEmployeeDal employeeDal = new EfEmployeeDal();

      var result = employeeDal.GetAll();

      Assert.AreEqual(9, result.Count);
    }

    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_employees()
    {
      EfEmployeeDal employeeDal = new EfEmployeeDal();
      

      var result = employeeDal.GetAll(e=>e.TitleOfCourtesy == "Ms.");

      Assert.AreEqual(4, result.Count);
    }
    [TestMethod]
    public void Get_all_with_parameter_returns_filtered_employees2()
    {
      EfEmployeeDal employeeDal = new EfEmployeeDal();


      var result = employeeDal.GetAll(e => e.Title == "Sales Representative");

      Assert.AreEqual(6, result.Count);
    }


  }
}