using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.ViewModels;
using DevFreela.Infraestructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Aplication.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SkillViewModel> GetAll()
        {
            var skills = _dbContext.Skills;

            var skillsViewModel = skills.
                Select(s => new SkillViewModel(s.Id, s.Description)).ToList();

            return skillsViewModel;
        }
    }
}
