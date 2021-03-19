using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.BrandName).NotEmpty();
            RuleFor(p => p.BrandName).MinimumLength(2);
            RuleFor(p => p.BrandName).Must(StartWithUpperCase).WithMessage("Marka ismi büyük harfle başlamalıdır");
        }

        private bool StartWithUpperCase(string arg)
        {
            for (int i = 0; i < 1; i++)
            {
                char character = arg[i];

                if (Char.IsUpper(character)) return true;
            }
            return false;
        }        
    }
}
