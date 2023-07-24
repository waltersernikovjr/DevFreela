using DevFreela.Aplication.Commands.CreateProject;
using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Test",
                Description = "Test",
                TotalCost = 50000,
                IdClient = 1,
                IdFreelance = 2
            };

            var createProjectCommandHandler = new CreateProjectHandler(projectRepositoryMock.Object);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new System.Threading.CancellationToken());


            // Assert
            projectRepositoryMock.Verify(pr => pr.CreateAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
