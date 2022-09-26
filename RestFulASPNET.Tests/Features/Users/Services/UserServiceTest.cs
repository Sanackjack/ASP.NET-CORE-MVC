using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RestFulASPNET.DTOs.Entities;
using RestFulASPNET.DTOs.Repositories;
using RestFulASPNET.Features.Users.Models;
using RestFulASPNET.Features.Users.Services;
using RestFulASPNET.models;
namespace RestFulASPNET.Tests.Features.Users.Services
{
	public class UserServiceTest
	{
        private UserService service;
        private Mock<IUserRepository> reposityMock;
		public UserServiceTest()
		{
            reposityMock = new Mock<IUserRepository>();
            service = new UserService(reposityMock.Object);
        }

        [Fact]
        public void Test_Case_GetUserById_Success()
        {
            //arrange
            User user = new User
            {
                Name = "John",
                Age = 10
            };
            reposityMock.Setup(p => p.GetUserById(It.IsAny<int>())).Returns(user);

            //act
            var result = service.GetUserById("1");

            //assert
            Assert.NotNull(result);
            Assert.IsType<GenericResponse>(result);

            var data = result.data as UserResponseModel;
            Assert.Equal("John", data.Name);
            Assert.Equal(10, data.Age);
        }
    }
}

