using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVC02.Models.ViewModels;

namespace MVC02.Services
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

        public async Task<bool> UserExist(string email)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            return user != null;

        }

        internal async Task<bool>DoesUserBelongToRole(string rolename, ClaimsPrincipal user)
        {

            var identityUser = await _userManager.GetUserAsync(user);

            if (identityUser == null)
            {
                return false;
            }

            bool userHasRole = await _userManager.IsInRoleAsync(identityUser, rolename);

            return userHasRole;
        }

        public async Task AddRoleToUser(AddRoleVm addrole)
        {
            IdentityResult roleResult;
            var role2 = new IdentityRole(addrole.Role);
            roleResult = await _roleManager.CreateAsync(role2);

            IdentityUser user = await _userManager.FindByEmailAsync(addrole.Email);
            await _userManager.AddToRoleAsync(user, addrole.Role);

        }

    }
}