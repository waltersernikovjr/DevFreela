using DevFreela.Aplication.InputModels;
using DevFreela.Aplication.ViewModels;

namespace DevFreela.Aplication.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(int id);

        int Create(NewUserInputModel inputModel);

        bool Login(LoginUserInputModel inputModel);
    }
}
