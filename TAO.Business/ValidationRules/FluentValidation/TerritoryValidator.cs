using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TAO.Entities.Concrete;

namespace TAO.Business.ValidationRules.FluentValidation
{
  public class TerritoryValidator:AbstractValidator<Territory>
  {
    public TerritoryValidator()
    {
      RuleFor(t => t.TerritoryID).NotEmpty();
      RuleFor(t=>t.TerritoryDescription).NotEmpty();
      RuleFor(t=>t.RegionID).NotEmpty();
    }
  }
}
