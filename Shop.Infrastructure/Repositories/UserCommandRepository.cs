using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class UserCommandRepository: IBaseRepository<User> , IUserCommandRepository
    {
        public UserCommandRepository(ShopDbContext context): base(context)
        {
            
        }
    }
}
