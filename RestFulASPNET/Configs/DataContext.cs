using System;
using Microsoft.EntityFrameworkCore;
using RestFulASPNET.DTOs.Entities;

namespace RestFulASPNET.Configs
{
	public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
    }
}

