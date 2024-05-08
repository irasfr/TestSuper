using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using System.Threading.Tasks;
using Domain;
using Configuration;

namespace Persistence
{
    public class PerDbContext : DbContext, IDbContext
    {
        public DbSet<Users> User {  get; set; }
        public PerDbContext(DbContextOptions<PerDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
