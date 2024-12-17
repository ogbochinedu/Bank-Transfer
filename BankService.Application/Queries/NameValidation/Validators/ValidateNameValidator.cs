using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Queries.NameValidation.Validators
{
    public class ValidateNameValidator : AbstractValidator<ValidateNameQuery>
    {
        public ValidateNameValidator()
        {
            RuleFor(x => x.AccountNumber).NotEmpty().Length(10);
            RuleFor(x => x.BankCode).NotEmpty();
        }
    }

}
