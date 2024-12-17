using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Domain.Dto
{
    public class ApiResponse
    {
        public bool Success { get; set; }        
        public string Message { get; set; }     
        public dynamic Data { get; set; }             
        public List<string> Errors { get; set; } 

        public ApiResponse()
        {
            Errors = new List<string>();
        }
    }
}
