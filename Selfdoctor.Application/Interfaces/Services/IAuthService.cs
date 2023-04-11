using Microsoft.AspNetCore.Identity;
using Selfdoctor.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(UserInsertDto user);
        Task<UserSessionDto> LoginAsync(string userName, string password);
    } 
}
