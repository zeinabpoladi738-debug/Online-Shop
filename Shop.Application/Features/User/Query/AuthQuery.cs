using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.User.Query
{
    public record AuthQuery:IRequest<bool>
    { 
        public required string MobileNumber { get; set; }
        public required int OtpCode { get; set; }   
    }
}
