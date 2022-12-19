using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.Entities.Concrete;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;

namespace TAO.Business.Abstract
{
  public interface ICategoryService
  {
    IResult Add(Category category);
    IResult Delete(Category category);
    IResult Update(Category category);
    IDataResult<List<Category>> GetAll();
    IDataResult<List<Category>> GetByCategoryId(int categoryId);
    IDataResult<List<Category>> GetByCategoryName(string categoryName);
    IDataResult<List<Category>> GetByCategoryDescription(string description);
    

  }
}
