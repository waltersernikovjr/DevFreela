using MediatR;

namespace DevFreela.Aplication.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
