using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RestFulASPNET.Features.Users.Controllers;
using RestFulASPNET.Features.Users.Models;
using RestFulASPNET.Features.Users.Services;
using RestFulASPNET.models;

namespace RestFulASPNET.Tests.Features.Users.Controllers
{
	public class UserControllerTest
	{
 
        private UserController controller;
        private Mock<IUserService> serviceMock;

        public UserControllerTest() {
            //setup
            serviceMock = new Mock<IUserService>();
            controller = new UserController(serviceMock.Object);
        }


        [Fact]
        public void Test_Case_GetUserById_Success()
        {
            //arrange
            UserResponseModel userResponse = new UserResponseModel
            {
                Name = "John",
                Age = 10
            };

            var  response = new GenericResponse(new StatusResponse("0", "success"), userResponse);
            serviceMock.Setup(p => p.GetUserById(It.IsAny<string>())).Returns(response);

            //act
            var result = controller.GetUserById("1");

            //assert
            Assert.NotNull(result);

            var okObjectResult = result as OkObjectResult;
            Assert.IsType<GenericResponse>(okObjectResult.Value);

            var responseModel = okObjectResult.Value as GenericResponse;
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.NotNull(responseModel);

            var data = responseModel.data as UserResponseModel;
            Assert.Equal("John",data.Name);
            Assert.Equal(10, data.Age);
        }
    }
}

