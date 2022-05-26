using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
    public class KategoriValidator:BaseValidator<KategoriDto>
    {
        public KategoriValidator()
        {
            RuleFor(x => x.KategoriAdi).NotEmpty().NotNull().WithMessage(requiredMessage).MaximumLength(100);
        }
    }
}
