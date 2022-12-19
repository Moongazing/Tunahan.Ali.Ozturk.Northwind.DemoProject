using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TAO.DataAccess.Abstract;
using TAO.Entities.ComplexTypes;
using TAO.Entities.Concrete;
using TAO_Core.DataAccess.EntityFramework;

namespace TAO.DataAccess.Concrete.EntityFramework.Dals
{
  public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
  {
    public List<ProductDetailsDto> GetProductDetails()
    {
      using (var context = new NorthwindContext())
      {
        var result = from product in context.Products
          join category in context.Categories on product.CategoryID equals category.CategoryID
          join supplier in context.Suppliers on product.SupplierID equals supplier.SupplierID
          select new ProductDetailsDto
          {
            product = product,
            CategoryName = category.CategoryName,
            SupplierName = supplier.CompanyName
          };
        return result.ToList();

      }
    }
  }
}
