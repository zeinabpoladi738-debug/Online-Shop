using Shop.Domain.DTO;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface IOtpRedisRepository : IBaseRepository<Otp>
    {
    }
}
