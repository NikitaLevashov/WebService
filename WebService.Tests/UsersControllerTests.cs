using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WebService.BLL.Interfaces;
using WebService.Controllers;
using WebService.Models;
using Xunit;

namespace WebService.Tests
{
    public class UsersControllerTests
    {
        private readonly UsersController _controller;
        private readonly IUserService _service;
        private readonly ILogger<UsersController> _logger;
        public UsersControllerTests()
        {
            _service = new UserServiceFake();
            _logger = new Mock<ILogger<UsersController>>().Object;

            _controller = new UsersController(_service, _logger);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Arrange
            var testCount = 3;
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<User>>(okResult.Value);
            Assert.Equal(testCount, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var testId = 100;
            // Act
            var notFoundResult = _controller.Get(testId);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 1;
            // Act
            var okResult = _controller.Get(testId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = 1;
            var testName = "Nikita";
            // Act
            var okResult = _controller.Get(testId).Result as OkObjectResult;
            // Assert
            Assert.IsType<User>(okResult.Value);
            Assert.Equal(testName, (okResult.Value as User).Name);
        }

        [Fact]
        public void Post_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var testItem = new User()
            {
                Name = "TestNameTestNameTestNameTestName",
                Surname = "TestSurname",
                Details = new Details { Age = 11, Adress = "Minsk" }
            };

            _controller.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse = _controller.Post(testItem);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void Post_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var testItem = new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Details = new Details { Age = 11, Adress = "Minsk" }
            };
            // Act
            var createdResponse = _controller.Post(testItem);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Post_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Details = new Details { Age = 11, Adress = "Minsk"}
            };
            // Act
            var createdResponse = _controller.Post(testItem) as OkObjectResult;
            var item = createdResponse.Value as User;
            // Assert
            Assert.IsType<User>(item);
            Assert.Equal("TestName", item.Name);
        }

        [Fact]
        public void Delete_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var testId = 100;
            // Act
            var badResponse = _controller.Delete(testId);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Delete_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingId = 1;
            // Act
            var okResponse = _controller.Delete(existingId);
            // Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }
        [Fact]
        public void Delete_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 1;
            // Act
             _controller.Delete(existingId);
            // Assert
            Assert.Equal(2, _service.GetAll().Count());
        }

        [Fact]
        public void Put_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            User testItem = null;        
            int testId = 1;

            // Act
            var badResponse = _controller.Put(testId, testItem);
            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }

        [Fact]
        public void Put_InvalidIdPassed_ReturnsNotFound()
        {
            // Arrange
            var testItem = new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Details = new Details { Age = 11, Adress = "Minsk" }
            };
            int testId = 100;

            // Act
            var badResponse = _controller.Put(testId, testItem);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Put_ValidObjectPassed_ReturnsOkResultResponse()
        {
            // Arrange
            var testItem = new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Details = new Details { Age = 11, Adress = "Minsk" }
            };

            var testId = 1;
            // Act
            var createdResponse = _controller.Put(testId, testItem);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Put_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Details = new Details { Age = 11, Adress = "Minsk" }
            };

            var testId = 1;
            // Act
            var createdResponse = _controller.Put(testId, testItem) as OkObjectResult;
            var item = createdResponse.Value as User;

            // Assert
            Assert.IsType<User>(item);
            Assert.Equal("TestName", item.Name);
        }
    }
}
