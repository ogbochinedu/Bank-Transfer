using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Infrastructure.ThirdPartyClients.Interrface
{
    public interface IThirdPartyBankClientFactory
    {
        IThirdPartyBankClient GetBankClient(string bankCode);
    }
}
