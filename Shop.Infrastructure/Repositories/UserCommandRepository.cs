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
    public class UserCommandRepository: BaseRepository<User> , IUserCommandRepository
    {
        public UserCommandRepository(ShopDbContext context): base(context)
        {
            
        }

        public Task Insert(User user)
        {
            throw new NotImplementedException();
        }
    }
}
