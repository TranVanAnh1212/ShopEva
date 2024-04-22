using Microsoft.EntityFrameworkCore;
using ShopEva.Data.Infrastructure;
using ShopEva.Data.IRepositories;
using ShopEva.Models.Model;

namespace ShopEva.Data.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            var user = await DbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            return user;
        }
    }
}
