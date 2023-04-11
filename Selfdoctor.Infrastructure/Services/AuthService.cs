using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Selfdoctor.Application.Dtos.User;
using Selfdoctor.Application.Interfaces.Services;
using Selfdoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AuthService> _logger;
        private readonly IMapper _mapper;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AuthService> logger, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UserSessionDto> LoginAsync(string userName, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(userName);
                    return _mapper.Map<UserSessionDto>(user);
                }
                return null!;
            }
            catch(Exception ex)  
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<bool> RegisterUserAsync(UserInsertDto user)
        {
            try 
            { 
                var newUser = _mapper.Map<User>(user);
                var result = await _userManager.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)  
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
