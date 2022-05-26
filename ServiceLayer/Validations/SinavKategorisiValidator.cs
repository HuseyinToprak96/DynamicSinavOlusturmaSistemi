using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
    public class SinavKategorisiValidator:BaseValidator<SinavKategorisiDto>
    {
        public SinavKategorisiValidator()
        {
            RuleFor(x => x.KategoriAdi).NotNull().NotEmpty().WithMessage(requiredMessage).MaximumLength(30).WithMessage(maxMessage);
            RuleFor(x => x.SinavId).InclusiveBetween(1, int.MaxValue).WithMessage(Secim);
        }
    }
}
