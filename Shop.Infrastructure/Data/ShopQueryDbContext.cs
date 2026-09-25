using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Data
{
    public class ShopQueryDbContext: DbContext
    {
        protected readonly IConfiguration configuration;
        public ShopQueryDbContext (IConfiguration configuration)
        {
           this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(configuration.GetConnectionString("QueryDBConnection"));
        }
        public DbSet<User> Tbl_Users { get; set; }  
    }
}
