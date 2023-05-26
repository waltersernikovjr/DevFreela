using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Models;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.Services.Implementations;
using DevFreela.Aplication.InputModels;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _userService.GetById(id);

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewUserInputModel inputModel)
        {
            var id = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new {id = id }, inputModel);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginUserInputModel inputModel)
        {
            _userService.Login(inputModel);

            return NoContent();
        }
    }
}
