using DevFreela.Core.Repositories;
using DevFreela.Infraestructure.Persistence;
using DevFreela.Infraestructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.StartProject
{
    public class StartProjectHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public StartProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            project.Start();
            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
