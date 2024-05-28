﻿
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopEva.Data.Contexts;
using ShopEva.Data.IRepositories;
using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;
using ShopEva.Services.RequestMessage;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace ShopEva.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ShopEvaDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthRepository(ShopEvaDbContext db,
                                UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                IConfiguration configuration,
                                IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<ApplicationUser> GetByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestMessage> LoginAsync(LoginUserViewModel userVM)
        {
            var user = await _userManager.FindByNameAsync(userVM.UserName);
            string error_msg = "";

            if (user == null)
            {
                if (user == null)
                    error_msg = "User not found!";

                return new RequestMessage
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = 404,
                        Message = error_msg
                    }
                };
            }            

            var pass = await _userManager.CheckPasswordAsync(user, userVM.Password);
            var lockout = await _userManager.IsLockedOutAsync(user);
            var email = _userManager.IsEmailConfirmedAsync(user);
            var phone = _userManager.IsPhoneNumberConfirmedAsync(user);


            if (!pass)
                error_msg = "Password is incorrect!";

            //if (!lockout)
            //    error_msg = "Account is locked!";


            var res = await _signInManager.PasswordSignInAsync(userVM.UserName, userVM.Password, isPersistent: userVM.RememberMe, lockoutOnFailure: false);

            if (!res.Succeeded)
            {
                return new RequestMessage
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = 404,
                        Message = "Login falure!"
                    },
                    Result = res
                };
            }

            user.LatestLogin = DateTime.UtcNow;

            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Expired, "30"),
                new Claim(ClaimTypes.NameIdentifier, userVM.UserName),
                new Claim(ClaimTypes.Name, userVM.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var item in userRoles)
            {
                authClaim.Add(new Claim(ClaimTypes.Role, item.ToString()));
            }

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Identity_Jwt:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Identity_Jwt:ValidIssuer"],
                audience: _configuration["Identity_Jwt:ValidAudience"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha512Signature)
                );

            var token_result = new TokenViewModel
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return new RequestMessage
            {
                Success = true,
                Result = token_result
            };
        }

        public async Task<IdentityResult> RegisterAsync(RegisterUserViewModel userVM)
        {
            var user = new ApplicationUser
            {
                UserName = userVM.UserName,
                Email = userVM.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, userVM.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(userVM.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(userVM.Role));
                }

                await _userManager.AddToRoleAsync(user, userVM.Role);
            }

            return result;
        }

        public RequestMessage LogOutAsync()
        {
            _httpContextAccessor.HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return new RequestMessage { Success = true };
        }

        public Task<RequestMessage> RefreshToken(LoginUserViewModel user)
        {
            throw new NotImplementedException();
        }

    }
}