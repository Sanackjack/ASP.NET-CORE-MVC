using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestFulASPNET.DTOs.Entities
{
    [Table("Users", Schema = "dbo")]
    public class User
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

