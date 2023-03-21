/*
 * <Your-Product-Name>
 * Copyright (c) <Year-From>-<Year-To> <Your-Company-Name>
 *
 * Please configure this header in your SonarCloud/SonarQube quality profile.
 * You can also set it in SonarLint.xml additional file for SonarLint or standalone NuGet analyzer.
 */

using MicroFrontendDal.DTO.Management;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MicroFrontendDal.BusinessRules.AppDbContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<DtoSpGetAllUsers> GetAllUsers { get; set; }
        public virtual DbSet<DtoSpGetUserById> GetAllUserById { get; set; }
        public virtual DbSet<DtoSpGetTeamList> GetTeamList { get; set; }
        public virtual DbSet<DtoSpGetTaskBoard> GetTaskBoards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Retrive from AppSettings
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectionString = configuration["ConnectionStrings:DatabaseConnection"];

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
