using BankService.Application.Command.Transfers;
using BankService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Interfaces
{
    public interface ITransferService
    {
        Task<ApiResponse> TransferAsync(CreateTransferCommand command);
    }

}
