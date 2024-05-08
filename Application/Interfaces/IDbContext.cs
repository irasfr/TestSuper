using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Domain;


namespace Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Users> User { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
