using System;
using MediatR;
using Domain;
using Application.Interfaces;


namespace Application.Commands
{
    public class PostHandler : IRequestHandler<Post, Guid>
    {
        private readonly IDbContext _dbContext;
        public PostHandler(IDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(Post request, CancellationToken cancellationToken)
        {


            var User = new Users
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _dbContext.User.AddAsync(User, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return User.Id;

        }
    }
}
