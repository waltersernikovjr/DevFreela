using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using DevFreela.Infraestructure.Persistence.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Email, request.BirthDate, request.Password);

            return await _userRepository.CreateAsync(user);
        }
    }
}
