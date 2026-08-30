using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.User.Command
{
    public record AuthCommand : IRequest<bool>
    {
        public required string MobileNumber { get; set; }
        
    }
}
}
