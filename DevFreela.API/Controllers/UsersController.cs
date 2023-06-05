using DevFreela.Aplication.Commands.CreateUser;
using DevFreela.Aplication.Commands.LoginUser;
using DevFreela.Aplication.Queries.GetByIdUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdUserQuery(id);

            var usuario = await _mediator.Send(query);

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var model = await _mediator.Send(command);

            if(model is null)
            {
                return BadRequest("E-mail ou senha incorretos!");
            }

            return Ok(model);
        }
    }
}
