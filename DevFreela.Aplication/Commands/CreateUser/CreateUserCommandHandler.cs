using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infraestructure.Auth;
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
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            return await _userRepository.CreateAsync(user);
        }
    }
}
