using DevFreela.Core.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();

        Task<Project> GetByIdAsync(int id);

        Task<int> CreateAsync(Project project);

        Task CreateCommentAsync(ProjectComment comment);

        Task SaveChangesAsync();
    }
}
