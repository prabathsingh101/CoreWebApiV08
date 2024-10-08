﻿using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models;
using CoreWebApiV08.API.Models.Domain;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenService _tokenService;
        private readonly IUserService userService;
        private readonly ImsContext imsContext;

        public AuthController(DatabaseContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService, IUserService userService,
            ImsContext imsContext
            )
        {
            this._context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._tokenService = tokenService;
            this.userService = userService;
            this.imsContext = imsContext;
        }

        [HttpPost]
        [Route("ChangePassword")]
        [Produces("application/json")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var status = new Status();
            // check validations
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "please pass all the valid fields";
                return Ok(status);
            }
            // lets find the user
            var user = await userManager.FindByNameAsync(model.Username);
            if (user is null)
            {
                status.StatusCode = 0;
                status.Message = "invalid username";
                return Ok(status);
            }
            // check current password
            if (!await userManager.CheckPasswordAsync(user, model.CurrentPassword))
            {
                status.StatusCode = 0;
                status.Message = "invalid current password";
                return Ok(status);
            }

            // change password here
            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Failed to change password";
                return Ok(status);
            }
            status.StatusCode = 1;
            status.Message = "Password has changed successfully";
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        [Produces("application/json")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = _tokenService.GetToken(authClaims);
                var refreshToken = _tokenService.GetRefreshToken();
                var tokenInfo = _context.TokenInfo.FirstOrDefault(a => a.Usename == user.UserName);
                if (tokenInfo == null)
                {
                    var info = new TokenInfo
                    {
                        Usename = user.UserName,
                        RefreshToken = refreshToken,
                        RefreshTokenExpiry = DateTime.Now.AddDays(1)
                    };
                    _context.TokenInfo.Add(info);
                }

                else
                {
                    tokenInfo.RefreshToken = refreshToken;
                    tokenInfo.RefreshTokenExpiry = DateTime.Now.AddDays(1);
                }
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok(new LoginResponse
                {
                    Name = user.Name,
                    Username = user.UserName,
                    Token = token.TokenString,
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo,
                    StatusCode = 1,
                    Message = "Logged in"
                });

            }
            //login failed condition

            return Ok(
                new LoginResponse
                {
                    StatusCode = 0,
                    Message = "Invalid Username or Password",
                    Token = "",
                    Expiration = null
                });
        }

        [HttpPost]
        [Route("User-Registration")]
        [Produces("application/json")]
        public async Task<IActionResult> Registration([FromBody] RegistrationModel model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the required fields";
                return Ok(status);
            }
            // check if user exists
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User name already exists";
                return Ok(status);
            }
            var emailExists = await userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "Email id elready exists.";
                return Ok(status);
            }
            var user = new ApplicationUser
            {
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                Name = model.FirstName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PhoneNumber=model.PhoneNumber
            };
            // create a user here
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return Ok(status);
            }

            // add roles here
            // for admin registration UserRoles.Admin instead of UserRoles.Roles
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.User))
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }


            //await roleManager.CreateAsync(new IdentityRole(model.roles));
            //await userManager.AddToRoleAsync(user, model.roles);

            status.StatusCode = 1;
            status.Message = "User is created sucessfully.";
            return Ok(status);

        }

        // after registering admin we will comment this code, because i want only one admin in this application
        [HttpPost]
        [Route("Admin-Registration")]
        [Produces("application/json")]
        public async Task<IActionResult> RegistrationAdmin([FromBody] RegistrationModel model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the required fields";
                return Ok(status);
            }
            // check if user exists
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User name is already exists.";
                return Ok(status);
            }
            var emailExists = await userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "Email is already exists.";
                return Ok(status);
            }
            var user = new ApplicationUser
            {
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                Name = model.FirstName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };
            // create a user here
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return Ok(status);
            }

            // add roles here
            // for admin registration UserRoles.Admin instead of UserRoles.Roles
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            status.StatusCode = 1;
            status.Message = "User is created sucessfully.";
            return Ok(status);

        }

        [HttpGet]
        [Route("GetName")]
        [Authorize(Roles = "Admin")]
        [Produces("application/json")]
        public IActionResult GetName()
        {
            var userName = userService.GetMyName();
            return Ok(userName);
        }

        [HttpGet]
        [Route("GetRoleName")]
        [Authorize(Roles = "Admin")]
        [Produces("application/json")]
        public IActionResult GetRoleName()
        {
            var userName = userService.GetRoleName();
            return Ok(userName);
        }

        [HttpGet("getusers")]
        [Authorize(Roles = "Admin,User")]
        [Produces("application/json")]
        public async Task<IActionResult> getUsers()
        {
            string sqlquery = "EXEC sp_getUsers";

            var data = await imsContext.userdetails.FromSqlRaw(sqlquery).ToListAsync();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("getAllrole")]
        [Authorize(Roles = "Admin,User")]
        [Produces("application/json")]
        public async Task<IActionResult> getRole()
        {
            string sqlquery = "EXEC sp_GetRole";

            var data = await imsContext.getallroles.FromSqlRaw(sqlquery).ToListAsync();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
