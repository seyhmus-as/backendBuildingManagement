using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RenterValidator : AbstractValidator<Renter>
    {
        public RenterValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage(Messages.RenterNameNotNull);
            RuleFor(p => p.FirstName).Must(StartWithA).WithMessage(Messages.RenterNameMustStartA);
            /*RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);*/
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
