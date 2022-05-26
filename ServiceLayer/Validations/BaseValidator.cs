using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validations
{
    public class BaseValidator<T>:AbstractValidator<T>
    {
        public string Secim { get; } = "Bir Seçim Yapınız";
        public string maxMessage { get; } = "En fazla {MaxLength} karakter alabilir";
        public string minMessage { get; } = "En az {MinLength} karakter alabilir";
        public string aralik { get; } = "{From} ile {To} aralığında olmalıdır";
        public string requiredMessage { get; } = "{PropertName} is required";
    }
}
