using MediatR;

namespace Application.Commands
{
    public class Get : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
