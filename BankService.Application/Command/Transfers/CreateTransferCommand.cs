using BankService.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Command.Transfers
{
    public class CreateTransferCommand : IRequest<ApiResponse>
    {
        public string SenderAccountNumber { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string BankCode { get; set; }
    }

}
