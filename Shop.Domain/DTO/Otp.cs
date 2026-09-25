using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DTO
{
    public class Otp
    {
        public  Int64 UserId { get; set; }   
        public required int OtpCode { get; set; }  
        public bool IsUse {  get; set; }
        public string UserName { get; set; }
    }
}
