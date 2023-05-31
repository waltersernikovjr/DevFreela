using MediatR;

namespace DevFreela.Aplication.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
