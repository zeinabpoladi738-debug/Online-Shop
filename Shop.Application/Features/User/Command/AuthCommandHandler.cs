using AutoMapper;
using MediatR;
using Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.User.Command
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, bool>
    {
        private readonly IOtpRedisRepository _otpRedisRepository;
        private readonly IUserCommandRepository _userCommandRepository; 
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IMapper mapper;

        public AuthCommandHandler(IOtpRedisRepository otpRedisRepository, IUserCommandRepository userCommandRepository,
            IUserQueryRepository userQueryRepository, IMapper _mapper)
        {
            _otpRedisRepository = otpRedisRepository;
            _userCommandRepository = userCommandRepository; 
            _userQueryRepository = userQueryRepository; 
            mapper = _mapper;   
           
        }
        public async Task<bool> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userobj = mapper.Map<Shop.Domain.Entities.User>(request);
                var user = await _userQueryRepository.GetUserAsync(request.MobileNumber);
                if (userobj == null) 
                {
                    Random random = new Random();
                    var code = random.Next((int)1000.10000);
                    //ارسال پیامک به سرویس نوتفیکیشن
                    userobj.UserName = request.MobileNumber;
                    await _userCommandRepository.Insert(userobj);
                    await _otpRedisRepository.Insert(new Domain.DTO.Otp { UserName = userobj.MobileNumber, OtpCode = code, IsUse = false });
                    
                }
                else
                {
                    Random random = new Random();
                    var code = random.Next(1000, 10000);
                    // ارسال پیامک به سرویس نوتفیکیشن 
                    userobj.UserName = request.MobileNumber;
                    await _otpRedisRepository.Insert(new Domain.DTO.Otp { UserName = user.MobileNumber, OtpCode = code, IsUse = false });

                }
                return true;
            }
            catch (Exception ex)
            {
                // لاگ خطا
                return false;
            }

        }
    }
}
