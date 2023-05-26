using DevFreela.Aplication.InputModels;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.ViewModels;
using DevFreela.Core.Entites;
using DevFreela.Infraestructure.Persistence;
using System.Linq;

namespace DevFreela.Aplication.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate, inputModel.Password);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            var userViewModel = new UserViewModel(user.FullName, user.Email, user.BirthDate);

            return userViewModel;
        }

        public bool Login(LoginUserInputModel inputModel)
        {
            return _dbContext.Users.Any(u => u.Email == inputModel.Email && u.Password == inputModel.Password);
        }
    }
}
