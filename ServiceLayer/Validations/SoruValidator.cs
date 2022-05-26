using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
   public class SoruValidator:BaseValidator<SoruDto>
    {
        public SoruValidator()
        {
            RuleFor(x => x.soru).NotNull().NotEmpty().WithMessage(requiredMessage).MaximumLength(250).WithMessage(maxMessage).MinimumLength(10).WithMessage(minMessage);
            RuleFor(x => x.KategoriId).InclusiveBetween(1, int.MaxValue).WithMessage(Secim);
            RuleFor(x => x.soruTipi).IsInEnum();
        }
    }
}
