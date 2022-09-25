using System;
using Microsoft.AspNetCore.Mvc;
using RestFulASPNET;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using RestFulASPNET.Features.Users.Services;
using RestFulASPNET.Features.Users.Models;
using System.Reflection;
using RestFulASPNET.models;

namespace RestFulASPNET.Features.Users.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController :ControllerBase
	{

        private readonly IUserService userService;
        public UserController(IUserService userService)
		{
            this.userService = userService;
		}

        [HttpGet("get/{id}", Name = "GetUserById")]
       // [ValidateActionParameters]
        public IActionResult GetUserById([FromRoute][Required] string id)
        {
            GenericResponse viewModel = userService.GetUserById(id);

            if (viewModel != null)
            {
                return new OkObjectResult(viewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUser([FromBody][Required] UserRequestModel viewModel)
        {
            UserResponseModel user = userService.CreateUser(viewModel);

             return new OkObjectResult(user);

        }

    }
}

