using Shop.Domain.Entities;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface IUserCommandRepository:IBaseRepository<User>
    {
    }
}
