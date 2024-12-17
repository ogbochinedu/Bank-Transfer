using BankService.Application.Command.Transfers.Validators;
using BankService.Application.Interfaces;
using BankService.Domain.Dto;
using BankService.Infrastructure.ThirdPartyClients.Interrface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Command.Transfers
{
    public class CreateTransferHandler : IRequestHandler<CreateTransferCommand, ApiResponse>
    {
        private readonly IThirdPartyBankClientFactory _bankClientFactory;


        public CreateTransferHandler(IThirdPartyBankClientFactory bankClientFactory)
        {
            _bankClientFactory = bankClientFactory;
        }

        public async Task<ApiResponse> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var bankClient = _bankClientFactory.GetBankClient(request.BankCode);

            // Use the resolved client to make the transfer
            return await bankClient.MakeTransferAsync(request.BankCode,request.SenderAccountNumber,request.SenderAccountNumber,request.Amount);
        }
    }

}
