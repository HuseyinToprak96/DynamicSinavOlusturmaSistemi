using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
    public class KullaniciValidator:BaseValidator<KullaniciDto>
    {
        public KullaniciValidator()
        {
            RuleFor(x => x.Ad).NotNull().NotEmpty().WithMessage(requiredMessage).MaximumLength(25).WithMessage(maxMessage).MinimumLength(3).WithMessage(minMessage);
            RuleFor(x => x.Soyad).NotEmpty().NotNull().WithMessage(requiredMessage).MaximumLength(25).WithMessage(maxMessage).MinimumLength(3).WithMessage(minMessage);
            RuleFor(x => x.Numara).MinimumLength(5).MaximumLength(5);
            RuleFor(x => x.yetki).IsInEnum();
        }
    }
}
