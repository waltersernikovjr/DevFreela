using DevFreela.Core.Entites;
using DevFreela.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.CreateComment
{
    public class CreateProjectCommentHandler : IRequestHandler<CreateProjectCommentCommand>
    {
        private readonly DevFreelaDbContext _dbContext;

        public CreateProjectCommentHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _dbContext.ProjectComments.AddAsync(comment);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
