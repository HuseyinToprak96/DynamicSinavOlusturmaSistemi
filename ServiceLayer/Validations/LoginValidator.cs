using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
    public class LoginValidator:BaseValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.KullaniciAdi).NotNull().NotEmpty().WithMessage(requiredMessage).MaximumLength(25).WithMessage(maxMessage).MinimumLength(5).WithMessage(minMessage);
            RuleFor(x => x.Sifre).NotEmpty().NotNull().WithMessage(requiredMessage).MaximumLength(25).WithMessage(maxMessage).MinimumLength(10).WithMessage(minMessage);
            
        }
    }
}
