using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TAO.Entities.Concrete;

namespace TAO.Business.ValidationRules.FluentValidation
{
  public class CustomerValidator:AbstractValidator<Customer>
  {
    public CustomerValidator()
    {

      RuleFor(c => c.CompanyName).NotEmpty();
      RuleFor(c => c.ContactName).NotEmpty();
      RuleFor(c => c.ContactTitle).NotEmpty();
      RuleFor(c => c.Address).NotEmpty();
      RuleFor(c => c.Region).NotEmpty();
      RuleFor(c => c.City).NotEmpty();
      RuleFor(c => c.Phone).NotEmpty();
      RuleFor(c => c.Fax).NotEmpty();
      RuleFor(c => c.Phone).NotEmpty();
      RuleFor(c => c.Country).NotEmpty();
      RuleFor(c => c.PostalCode).NotEmpty();



    }
  }
}
