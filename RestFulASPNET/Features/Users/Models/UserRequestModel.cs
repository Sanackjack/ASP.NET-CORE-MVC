
using System.ComponentModel.DataAnnotations;

namespace RestFulASPNET.Features.Users.Models
{
	public class UserRequestModel
	{
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }

    }

}

