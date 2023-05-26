using Dapper;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.ViewModels;
using DevFreela.Core.Entites;
using DevFreela.Infraestructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

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
