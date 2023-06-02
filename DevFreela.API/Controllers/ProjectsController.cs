using DevFreela.Aplication.Commands.CreateComment;
using DevFreela.Aplication.Commands.CreateProject;
using DevFreela.Aplication.Commands.DeleteProject;
using DevFreela.Aplication.Commands.FinishProject;
using DevFreela.Aplication.Commands.StartProject;
using DevFreela.Aplication.Commands.UpdateProject;
using DevFreela.Aplication.Queries.GetAllProject;
using DevFreela.Aplication.Queries.GetByIdProject;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string queryString)
        {
            var query = new GetAllProjectsQuery(queryString);
            var projects = await _mediator.Send(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdProjectQuery(id);

            var project = await _mediator.Send(query);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(messages);
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateProjectCommand command)
        {

            if (command.Description.Length > 50)
            {
                return BadRequest();
            }
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var command = new DeleteProjectCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateProjectCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
