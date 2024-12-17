using BankService.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Application.Queries.NameValidation
{
    public class ValidateNameQuery : IRequest<ApiResponse>
    {
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
    }

}
