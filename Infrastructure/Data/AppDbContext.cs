using DAL.Entities;
using DAL.Entities.Candidat;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
                Console.WriteLine(connectionString);
            }
        }



        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Candidat> Candidats { get; set; }
    }
}
