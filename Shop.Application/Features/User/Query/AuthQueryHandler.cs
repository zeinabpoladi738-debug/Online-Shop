using Auth;
using MediatR;
using Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Shop.Application.Features.User.Query
{
    public class AuthQueryHandler : IRequestHandler<AuthQuery, bool>
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IOtpRedisRepository _redisRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public AuthQueryHandler(IJwtHandler jwtHandler, IOtpRedisRepository otpRedisRepository,
            IUserQueryRepository userQueryRepository)
        {
            _jwtHandler = jwtHandler;
            _redisRepository = otpRedisRepository;
            _userQueryRepository = userQueryRepository; 
        } 

        public async Task<bool> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _redisRepository.Getdata(request.MobileNumber);
                if (res == null) return false;
                if (res.OtpCode == request.OtpCode)
                {
                    var user = await _userQueryRepository.GetUserAsync(request.MobileNumber);
                    var token = _jwtHandler.Create(user.Id);
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

                    
        }
    }
}
