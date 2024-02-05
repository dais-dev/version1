using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAssetAppASP.Models;

namespace MyAssetAppASP.Data
{
    public class MyAssetAppASPContext : DbContext
    {
        public MyAssetAppASPContext (DbContextOptions<MyAssetAppASPContext> options)
            : base(options)
        {
        }

        public DbSet<MyAssetAppASP.Models.Asset> Asset { get; set; } = default!;
        public DbSet<MyAssetAppASP.Models.User> User {get; set; }
        public DbSet<MyAssetAppASP.Models.Login> Login {get; set; }
    }
}
