using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Shop.Application.Interfaces;
using Shop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class OtpRedisRepository : IOtpRedisRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConfiguration _configuration;
        public OtpRedisRepository(IDistributedCache distributedCache, IConfiguration configuration )
        {
            _distributedCache = distributedCache;
            _configuration = configuration;
        }

        public Task<Otp> Add(Otp entity)
        {
            throw new NotImplementedException();
        }

        public Task<Otp> AddAsync(Otp entity)
        {
            int time = Convert.ToInt32(_configuration.GetSection("Otp:OtpTime").Value);
            _distributedCache.SetString(entity.UserId.ToSrting(), JasonConvert.SerializeObject(entity), new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(time)).SetAbsoluteExpiration(TimeSpan.FromMinutes(time)));
            return true;
        }

        public IQueryable<Otp> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<Otp> DeleteAsync(Otp entity)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteTransactionAsync(Func<Task> action)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Otp>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Otp>> GetAsync(Expression<Func<Otp, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Otp>>? GetAsync(Expression<Func<Otp, bool>>? predicate = null, Func<IQueryable<Otp>?, IOrderedQueryable<Otp>>? orderBy = null, string? includeString = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Otp>> GetAsync(Expression<Func<Otp, bool>>? predicate = null, Func<IQueryable<Otp>?, IOrderedQueryable<Otp>>? orderBy = null, List<Expression<Func<Otp, object>>>? includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Otp?> GetByEntityAsNoTrackingFirstAsync(Expression<Func<Otp, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Otp?> GetByEntityFirstAsync(Expression<Func<Otp, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Otp>> GetByEntityListAsync(Expression<Func<Otp, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Otp?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Otp?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Otp?> GetLastRowAsync(Expression<Func<Otp, object>> orderByKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Otp?> GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Otp entity)
        {
            throw new NotImplementedException();
        }

        public Task<Otp?> UpdateByEntityFirstAsync(Expression<Func<Otp, bool>> predicate, Action<Otp> updateAction)
        {
            throw new NotImplementedException();
        }
    }
}
