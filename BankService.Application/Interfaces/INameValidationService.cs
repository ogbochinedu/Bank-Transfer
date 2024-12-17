using BankService.Application.Queries.NameValidation;
using BankService.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Interfaces
{
    public interface INameValidationService
    {
        Task<ApiResponse> ValidateNameAsync(ValidateNameQuery query);
    }

}
