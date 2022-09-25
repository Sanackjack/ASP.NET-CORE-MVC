using System;
using RestFulASPNET.models;
using RestFulASPNET.Features.Users.Models;
namespace RestFulASPNET.Features.Users.Services
{
	public interface IUserService
	{
        IEnumerable<UserResponseModel> GetUsers();
        //IEnumerable<UserResponseModel> GetUsersCriteria(UserCriteria criteria, ref PaginationHeader pagination, OrderCriteria order);
        //UserResponseModel GetUserById(string id);
        GenericResponse GetUserById(string id);
        UserResponseModel CreateUser(UserRequestModel userRequest);
        UserResponseModel UpdateUser(UserRequestModel userRequest);
        void DeleteUser(long id);
        


    }
}

