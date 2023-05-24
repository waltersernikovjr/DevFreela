using DevFreela.Aplication.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Aplication.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillViewModel> GetAll();
    }
}
