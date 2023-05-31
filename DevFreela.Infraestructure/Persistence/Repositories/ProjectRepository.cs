using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Infraestructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await SaveChangesAsync();

            return project.Id;
        }

        public async Task CreateCommentAsync(ProjectComment comment)
        {
            await _dbContext.ProjectComments.AddAsync(comment);

            await SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
           return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
