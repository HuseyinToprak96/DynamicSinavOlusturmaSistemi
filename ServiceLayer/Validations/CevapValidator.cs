using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
    public class CevapValidator:BaseValidator<CevapDto>
    {
        public CevapValidator()
        {
            RuleFor(x => x.cevap).NotNull().NotEmpty().WithMessage(requiredMessage).MaximumLength(100).WithMessage(maxMessage).MinimumLength(3).WithMessage(minMessage);
            
        }
    }
}
