using BankService.Application.Interfaces;
using BankService.Application.Queries.NameValidation;
using BankService.Domain.Dto;
using BankService.Infrastructure.ThirdPartyClients.Interrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Services
{
    public class NameValidationService : INameValidationService
    {
        private readonly IThirdPartyBankClient _bankClient;

        public NameValidationService(IThirdPartyBankClient bankClient)
        {
            _bankClient = bankClient;
        }

        public async Task<ApiResponse> ValidateNameAsync(ValidateNameQuery query)
        {
            return await _bankClient.GetAccountNameAsync(query.BankCode, query.AccountNumber);
        }
    }

}
