using DevFreela.Core.Repositories;
using DevFreela.Infraestructure.Persistence;
using DevFreela.Infraestructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);
            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
