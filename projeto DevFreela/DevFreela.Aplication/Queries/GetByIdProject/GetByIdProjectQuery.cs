using DevFreela.Aplication.ViewModels;
using MediatR;

namespace DevFreela.Aplication.Queries.GetByIdProject
{
    public class GetByIdProjectQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetByIdProjectQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
