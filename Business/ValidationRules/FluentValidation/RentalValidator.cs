using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.RentDate).NotEmpty();
            RuleFor(P => P.CarId).NotEmpty();
            RuleFor(p => p.RentDate).LessThan(p => p.ReturnDate);
        }
    }
}
