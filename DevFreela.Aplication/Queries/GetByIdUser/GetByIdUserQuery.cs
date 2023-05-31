using DevFreela.Aplication.ViewModels;
using MediatR;

namespace DevFreela.Aplication.Queries.GetByIdUser
{
    public class GetByIdUserQuery : IRequest<UserViewModel>
    {
        public GetByIdUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
