using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TAO.Entities.Concrete;

namespace TAO.Business.ValidationRules.FluentValidation
{
  public class CategoryValidator:AbstractValidator<Category>
  {
    public CategoryValidator()
    {
      RuleFor(c => c.CategoryName).NotEmpty();
      RuleFor(c => c.Description).NotEmpty();
      
    }
  }
}
