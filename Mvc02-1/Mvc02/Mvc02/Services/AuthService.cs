using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Mvc02.ViewModel;

namespace Mvc02.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        internal async Task<bool> UserExist(string email)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(email);

            return user != null;
        }

        internal async Task AddRoleToUser(AddRoleVm addrole)
        {

            IdentityUser user = await _userManager.FindByEmailAsync(addrole.Admin.Email);
            //IdentityRole role = await _roleManager.FindByNameAsync(addrole.Admin.Role);

            await _userManager.AddToRoleAsync(user, addrole.Admin.Role);
        }

        internal async Task CreateRole(string role)
        {
            IdentityRole identityRole = new IdentityRole();
            identityRole.Name = role;

            IdentityResult result = new IdentityResult();
            result = await _roleManager.CreateAsync(identityRole);
        }

        internal async Task<bool> RoleExist(string role)
        {
            IdentityRole identityRole = await _roleManager.FindByNameAsync(role);

            return identityRole != null;
        }
    }
}