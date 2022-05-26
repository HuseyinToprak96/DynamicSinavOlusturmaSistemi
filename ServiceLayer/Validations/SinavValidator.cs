using CoreLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
    public class SinavValidator:BaseValidator<SinavDto>
    {

        public SinavValidator()
        {
            RuleFor(x => x.Aciklama).MaximumLength(500).WithMessage(maxMessage).MinimumLength(50).WithMessage(minMessage);
            RuleFor(x => x.GecmeNotu).InclusiveBetween(45, 70).WithMessage(aralik);
            RuleFor(x => x.SinavAdi).MaximumLength(80).WithMessage(maxMessage).MinimumLength(4).WithMessage(minMessage);
            RuleFor(x => x.Sure).InclusiveBetween(10, 180).WithMessage(aralik);
            
        }
    }
}
