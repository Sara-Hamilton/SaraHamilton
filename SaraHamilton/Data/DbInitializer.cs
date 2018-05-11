using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaraHamilton.Models;

//The code on this page was found at https://stackoverflow.com/questions/45985698/seed-asp-net-core-1-1-database-with-a-default-super-user

public interface IDbInitializer
{
    void Initialize();
}

namespace SaraHamilton.Data
{
     public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //This example just creates an Administrator role and one Admin users
        public async void Initialize()
        {
            //create database schema if none exists
            _context.Database.EnsureCreated();

            //Create the default Admin account
            string password = "supersecretpassword";
            ApplicationUser user = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@example.com",
                EmailConfirmed = true
            };
            user.Claims.Add(new IdentityUserClaim<string> { ClaimType = ClaimTypes.Role, ClaimValue = "Admin" });
            var result = await _userManager.CreateAsync(user, password);
        }
    }
}
