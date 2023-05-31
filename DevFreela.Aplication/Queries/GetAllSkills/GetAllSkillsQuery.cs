using DevFreela.Aplication.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Aplication.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}
