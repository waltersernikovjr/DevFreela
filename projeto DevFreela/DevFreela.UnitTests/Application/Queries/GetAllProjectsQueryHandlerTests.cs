using DevFreela.Aplication.Queries.GetAllProject;
using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnTrheeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome Do Testes 1", "Descrição de Teste 1", 1, 2, 10000),
                new Project("Nome Do Testes 2", "Descrição de Teste 2", 1, 2, 20000),
                new Project("Nome Do Testes 3", "Descrição de Teste 3", 1, 2, 30000),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync()).ReturnsAsync(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync(), Times.Once);
        }
    }
}
