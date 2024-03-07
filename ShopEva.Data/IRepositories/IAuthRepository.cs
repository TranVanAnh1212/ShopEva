using Microsoft.AspNetCore.Identity;
using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;
using ShopEva.Services.RequestMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.IRepositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterAsync(RegisterUserViewModel user);
        Task<RequestMessage> LoginAsync(LoginUserViewModel user);
        Task<ApplicationUser> GetByUserName(string username);
    }
}
