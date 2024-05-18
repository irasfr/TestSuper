using MediatR;

namespace Application.Commands
{
    public class Dele : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }

    }
}
