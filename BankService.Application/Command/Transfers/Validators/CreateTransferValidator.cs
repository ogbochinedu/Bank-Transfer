using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Command.Transfers.Validators
{
    public class CreateTransferValidator : AbstractValidator<CreateTransferCommand>
    {
        public CreateTransferValidator()
        {
            RuleFor(x => x.SenderAccountNumber).NotEmpty().Length(10);
            RuleFor(x => x.ReceiverAccountNumber).NotEmpty().Length(10);
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.BankCode).NotEmpty();
        }
    }

}
