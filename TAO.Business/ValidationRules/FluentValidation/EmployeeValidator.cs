using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TAO.Entities.Concrete;

namespace TAO.Business.ValidationRules.FluentValidation
{
  public class EmployeeValidator:AbstractValidator<Employee>
  {
    public EmployeeValidator()
    {
      
    }
  }
}
