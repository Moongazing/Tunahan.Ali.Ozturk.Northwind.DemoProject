using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Execution;
using TAO.Business.Abstract;
using TAO.Business.Constans;
using TAO.Business.ValidationRules.FluentValidation;
using TAO.DataAccess.Abstract;
using TAO.Entities.Concrete;
using TAO_Core.Aspects.Autofac.Caching;
using TAO_Core.Aspects.Autofac.Performance;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.Business.Concrete
{
  public class CategoryManager:ICategoryService
  {
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
      _categoryDal = categoryDal;
    }

    #region BusinessRules



    #endregion
    [PerformanceAspect(10)]
    [CacheRemoveAspect("ICategoryService.Get")]
    [ValidationAspect(typeof(CategoryValidator))]
    public IResult Add(Category category) 
    {
      _categoryDal.Add(category);
      return new SuccessResult(Messages.CategoryAdded);
    }
    [PerformanceAspect(10)]
    public IResult Delete(Category category)
    {
      _categoryDal.Delete(category);
      return new SuccessResult(Messages.CategoryDeleted);
    }
    [ValidationAspect(typeof(CategoryValidator))]
    public IResult Update(Category category)
    {
      _categoryDal.Update(category);
      return new SuccessResult(Messages.CategoryUpdated);
    }
    [CacheAspect()]
    [PerformanceAspect(10)]
    public IDataResult<List<Category>> GetAll()
    {
      return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);
    }
    [CacheAspect()]
    [PerformanceAspect(10)]
    public IDataResult<List<Category>> GetByCategoryId(int categoryId)
    {
      return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c => c.CategoryID == categoryId),
        Messages.CategoriesListedById);
    }
    [CacheAspect()]
    [PerformanceAspect(10)]
    public IDataResult<List<Category>> GetByCategoryName(string categoryName)
    {
      return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c =>
        c.CategoryName == categoryName || c.CategoryName.Contains(categoryName.ToLower())),Messages.CategoryNamesListed);
    }
    [CacheAspect()]
    [PerformanceAspect(10)]
    public IDataResult<List<Category>> GetByCategoryDescription(string description)
    {
      return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c =>
        c.Description == description || c.Description.Contains(description.ToLower())), Messages.CategoriesListedByDescription);
    }
  }
}
