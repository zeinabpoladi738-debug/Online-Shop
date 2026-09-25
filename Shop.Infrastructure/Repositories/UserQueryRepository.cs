using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Infrastructure.Data;

namespace Shop.Infrastructure.Repositories
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly ShopQueryDbContext _db;

        public UserQueryRepository(ShopQueryDbContext shopQueryDbContext)
        {
            _db = shopQueryDbContext;
        }

        public async Task<User> GetUserAsync(string mobilenumber)
        {
            var userfound = await _db.Tbl_Users
                .FirstOrDefaultAsync(p => p.MobileNumber == mobilenumber);

            return userfound;
        }
    }
}