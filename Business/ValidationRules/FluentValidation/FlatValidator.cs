using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class FlatValidator : AbstractValidator<Flat>
    {
        public FlatValidator()
        {
            RuleFor(p => p.PriceOfRent).NotEmpty();
        }
    }
}
