using System;
using Microsoft.AspNetCore.Mvc;
using RestFulASPNET.Features.Users.Models;
using RestFulASPNET.DTOs.Repositories;
using RestFulASPNET.DTOs.Entities;
using RestFulASPNET.models;
using RestFulASPNET.Exceptions;
using RestFulASPNET.Constants;

namespace RestFulASPNET.Features.Users.Services
{
	public class UserService : IUserService
	{
        private readonly IUserRepository repository;
        public UserService(IUserRepository userRepository)
		{
            repository = userRepository;
		}

        public UserResponseModel CreateUser(UserRequestModel userRequest)
        {

            User user = new User();
            user.Name = userRequest.Name;
            user.Age = userRequest.Age; 

            repository.CreateUser(user);
            repository.Save();

            return new UserResponseModel { Name = user.Name , Age = user.Age};
        }

        public GenericResponse GetUserById(string id)
        {

            User user = repository.GetUserById(Int32.Parse(id));

            if (user == null)
            {
                throw new ServiceNotFoundException(ExceptionCode.NOTFOUND_EXCEPTION, "user not found");
            }

            UserResponseModel userResponse = new UserResponseModel
            {
                Name = user.Name,
                Age = user.Age
            };

            return new GenericResponse(new StatusResponse("0", "success"), userResponse);

        }


        public void DeleteUser(long id)
        {
            throw new NotImplementedException();
        }



        //public UserResponseModel GetUserById(string id)
        //{

        //    User user = repository.GetUserById(Int32.Parse(id));

        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    //throw new InvalidDataException();
        //    UserResponseModel userResponse = new UserResponseModel
        //    {
        //        Name = user.Name,
        //        Age = user.Age
        //    };

        //    return userResponse;
        //}

        public IEnumerable<UserResponseModel> GetUsers()
        {
             throw new NotImplementedException();

        }

        public UserResponseModel UpdateUser(UserRequestModel userRequest)
        {
            throw new NotImplementedException();
        }
    }
}

