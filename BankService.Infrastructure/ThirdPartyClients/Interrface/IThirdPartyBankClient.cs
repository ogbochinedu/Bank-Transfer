using BankService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Infrastructure.ThirdPartyClients.Interrface
{
    public interface IThirdPartyBankClient
    {
        Task<ApiResponse> GetAccountNameAsync(string bankCode, string accountNumber);
        Task<ApiResponse> MakeTransferAsync(string bankCode,string accountNumberFrom,string accountNumberTo, decimal Amount);

        string BankCode { get; } // Add a property to identify the bank code
    }

}
