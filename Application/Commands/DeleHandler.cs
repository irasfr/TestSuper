using Application.Interfaces;
using Application.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System;
using Domain;



namespace Application.Commands
{
    public class DeleteHandler : IRequestHandler<Dele, bool>
    {
        private readonly IDbContext _dbContext;
        public DeleteHandler(IDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> Handle(Dele request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.User.FindAsync(request.UserId);

            if (user == null)
            {
                throw new Exception($"User with ID not found");
            }

            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
