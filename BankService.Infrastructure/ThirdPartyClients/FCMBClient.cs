
using BankService.Domain.Dto;
using BankService.Infrastructure.ThirdPartyClients.Interrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Infrastructure.ThirdPartyClients
{
    public class FCMBClient : IThirdPartyBankClient
    {
        public string BankCode => "FCMB"; // FCMB's specific bank code

        public async Task<ApiResponse> GetAccountNameAsync(string bankCode, string accountNumber)
        {
            // Call FCMB API to fetch account name
            return await Task.FromResult(new ApiResponse() { Errors = null, Success = true, 
                Data = new AccountInfo() { AccountName = "John Doe", AccountNumber = "123" } }); 
        }

        public async Task<ApiResponse> MakeTransferAsync(string bankCode, string accountNumberFrom, string accountNumberTo, decimal Amount)
        {
            // Call FCMB API to initiate transfer
            return await Task.FromResult(new ApiResponse()
            {
                Errors = null,
                Success = true,
                Data = new TransferDto()
                {
                    Amount
                = Amount,
                    BankCode = bankCode,
                    ReceiverAccountNumber = accountNumberTo,
                    SenderAccountNumber = accountNumberFrom,
                    Status = "Pending"
                }
            });
        }

       
    }
}
