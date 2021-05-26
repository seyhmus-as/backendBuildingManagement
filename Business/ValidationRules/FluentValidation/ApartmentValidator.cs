using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ApartmentValidator : AbstractValidator<Apartment>
    {
        public ApartmentValidator()
        {
            RuleFor(p => p.ApartmentName).NotEmpty();
            RuleFor(p => p.NumberOfFloor).GreaterThanOrEqualTo(7);
            RuleFor(p => p.NumberOfFlat).NotEmpty();
            RuleFor(p => p.ApartmentName).MinimumLength(2);
            RuleFor(p => p).Must(p => p.NumberOfFlat > p.NumberOfFloor).WithMessage("Number of flat must be greater than number of floor");
        }
    }
}