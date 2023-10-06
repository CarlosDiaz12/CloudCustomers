using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services.Users;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace CloudCustomers.UnitTests.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService.
                        Setup(service => service.GetAllUsers())
                        .ReturnsAsync(UsersFixture.GetTestUsers());
            var systemUnderTask = new UsersController(mockUsersService.Object);
            // Act
            var result = (OkObjectResult)await systemUnderTask.Get();
            // Assert 
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokeUserService()
        {
            // Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService.
                        Setup(service => service.GetAllUsers())
                        .ReturnsAsync(UsersFixture.GetTestUsers());
            var systemUnderTask = new UsersController(mockUsersService.Object);
            // Act
            var result = await systemUnderTask.Get();

            // Assert 
            mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUsersServiceReturnsListOfUsers()
        {
            // Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService.
                Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            var systemUnderTask = new UsersController(mockUsersService.Object);
            // Act
            var result = await systemUnderTask.Get();

            // Assert

            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;

            objectResult.Value.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task Get_OnNotUsersFound_Returns404()
        {
            // Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());

            var systemUnderTask = new UsersController(mockUsersService.Object);
            // Act
            var result = await systemUnderTask.Get();

            // Assert

            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }

    }
}