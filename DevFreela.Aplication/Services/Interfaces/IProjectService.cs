using DevFreela.Aplication.InputModels;
using DevFreela.Aplication.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Aplication.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);

        ProjectDetailsViewModel GetById(int id);

        int Create(NewProjectInputModel inputModel);

        void Update(UpdateProjectInputModel inputModel);

        void Delete(int id);
        void CreateComment(CreateCommentInputModel inputModel);
        void Start(int id);
        void Finish(int id);

    }
}
