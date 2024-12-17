using BankService.Application.Interfaces;
using BankService.Domain.Dto;
using BankService.Infrastructure.ThirdPartyClients.Interrface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Queries.NameValidation
{
    public class ValidateNameHandler : IRequestHandler<ValidateNameQuery, ApiResponse>
    {
        private readonly IThirdPartyBankClientFactory _bankClientFactory;

        public ValidateNameHandler(IThirdPartyBankClientFactory bankClientFactory)
        {
            _bankClientFactory = bankClientFactory;
        }

        public async Task<ApiResponse> Handle(ValidateNameQuery request, CancellationToken cancellationToken)
        {
            var bankClient = _bankClientFactory.GetBankClient(request.BankCode);
            return await bankClient.GetAccountNameAsync(request.BankCode,request.AccountNumber);
        }
    }

}
