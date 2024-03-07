using Microsoft.AspNet.Identity;
using ShopEva.Data.ViewModels;

namespace ShopEva.Services.IServices
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterUserViewModel userVM);
    }
}
