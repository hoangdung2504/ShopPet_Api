using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_2021_API.Entities;

namespace web_2021_API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<User> users { get; set; }
        public DbSet<BaiViet> baiViets { get; set; }
        public DbSet<Quyen> quyens { get; set; }
    }
}
