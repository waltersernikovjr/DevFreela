using MediatR;

namespace DevFreela.Aplication.Commands.CreateComment
{
    public class CreateProjectCommentCommand : IRequest
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
