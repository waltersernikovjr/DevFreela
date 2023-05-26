using DevFreela.Aplication.InputModels;
using DevFreela.Aplication.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Aplication.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);

        ProjectDetailsViewModel GetById(int id);

        void Update(UpdateProjectInputModel inputModel);

        void Delete(int id);
        void Start(int id);
        void Finish(int id);

    }
}
