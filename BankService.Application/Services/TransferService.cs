using BankService.Application.Command.Transfers;
using BankService.Application.Interfaces;
using BankService.Domain.Dto;
using BankService.Infrastructure.ThirdPartyClients.Interrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IThirdPartyBankClient _bankClient;

        public TransferService(IThirdPartyBankClient bankClient)
        {
            _bankClient = bankClient;
        }

        public async Task<ApiResponse> TransferAsync(CreateTransferCommand command)
        {
            return await _bankClient.MakeTransferAsync(command.BankCode, command.SenderAccountNumber, command.ReceiverAccountNumber, command.Amount);
        }
    }

}
