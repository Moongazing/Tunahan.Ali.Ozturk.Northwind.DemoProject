using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TAO.Entities.Concrete;

namespace TAO.Business.ValidationRules.FluentValidation
{
  public class ProductValidator:AbstractValidator<Product>
  {
    public ProductValidator()
    {
      RuleFor(p => p.ProductName).NotEmpty();
      RuleFor(p => p.UnitPrice).NotEmpty();
      RuleFor(p => p.UnitsInStock).NotEmpty();
      RuleFor(p => p.UnitsOnOrder).NotEmpty();
      RuleFor(p => p.CategoryID).NotEmpty();
      RuleFor(p => p.QuantityPerUnit).NotEmpty();
      RuleFor(p => p.Discontinued).NotEmpty();
      RuleFor(p => p.ReorderLevel).NotEmpty();
      RuleFor(p => p.ProductID).NotEmpty();
      RuleFor(p => p.SupplierID).NotEmpty();
    }
  }
}
