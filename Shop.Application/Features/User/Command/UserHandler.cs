using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.User.Command
{
    public class UserHandler : IRequestHandler<UserCommand, bool>

    {
        public async Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            //await _dbContext.SaveachangesAsync(cancellationToken);
            return true;
        }
    }
}
