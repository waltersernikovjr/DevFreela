using MediatR;

namespace DevFreela.Aplication.Commands.StartProject
{
    public class StartProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
