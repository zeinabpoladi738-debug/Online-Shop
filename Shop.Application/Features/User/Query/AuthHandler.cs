using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.User.Query
{
    public class AuthHandler : IRequestHandler<AuthQuery, bool>
    {
        public async Task<bool> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
