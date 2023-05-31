using DevFreela.Aplication.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infraestructure.Persistence;
using DevFreela.Infraestructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Queries.GetByIdProject
{
    public class GetByIdProjectQueryHandler : IRequestHandler<GetByIdProjectQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public GetByIdProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }
    }
}
