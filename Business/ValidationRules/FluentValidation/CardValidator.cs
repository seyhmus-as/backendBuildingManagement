using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.IsIncome).NotEmpty();
        }
    }
}
