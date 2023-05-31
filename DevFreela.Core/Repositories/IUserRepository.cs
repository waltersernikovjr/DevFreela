using DevFreela.Core.Entites;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User user);

        Task<User> GetByIdAsync(int id);
    }
}
