using BankService.Infrastructure.ThirdPartyClients.Interrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Infrastructure.ThirdPartyClients
{
    public class ThirdPartyBankClientFactory : IThirdPartyBankClientFactory
    {
        private readonly IEnumerable<IThirdPartyBankClient> _bankClients;

        public ThirdPartyBankClientFactory(IEnumerable<IThirdPartyBankClient> bankClients)
        {
            _bankClients = bankClients;
        }

        public IThirdPartyBankClient GetBankClient(string bankCode)
        {
            var client = _bankClients.FirstOrDefault(c => c.BankCode.Equals(bankCode, StringComparison.OrdinalIgnoreCase));
            if (client == null)
            {
                throw new ArgumentException($"No bank client found for bank code {bankCode}");
            }
            return client;
        }
    }
}
