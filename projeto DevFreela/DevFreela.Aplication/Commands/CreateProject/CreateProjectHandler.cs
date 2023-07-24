using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using DevFreela.Infraestructure.Persistence;
using DevFreela.Infraestructure.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, int>
    {         
        private readonly IProjectRepository _projectRepository;

        public CreateProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdClient,
                                        request.IdFreelance, request.TotalCost);

            return await _projectRepository.CreateAsync(project);
        }
    }
}
