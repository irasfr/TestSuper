using System;
using MediatR;

namespace Application.Commands
{
    public class Post : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
