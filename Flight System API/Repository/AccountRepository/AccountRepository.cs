using Microsoft.AspNetCore.Identity;

namespace Flight_System_API.Repository.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> DeleteAsync(string userId)
        {
            var user = await _userManager.FindByNameAsync(userId);
            if (user != null)
            {
                return await _userManager.DeleteAsync(user);
            }
            return IdentityResult.Failed(new IdentityError { Description = "Xóa người dùng thất bại" });
        }

        public List<IdentityUser> GetAll()
        {
            return _userManager.Users.ToList();
        }

        public async Task<IdentityUser> GetById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IdentityResult> UpdateAsync(IdentityUser user)
        {
            return await _userManager.UpdateAsync(user);
        }


    }
}
