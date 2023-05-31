﻿using DevFreela.Core.Repositories;
using DevFreela.Infraestructure.Persistence;
using DevFreela.Infraestructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.FinishProject
{
    public class FinishProjectHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public FinishProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id) ;

            project.Finish();

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
