using Microsoft.AspNetCore.Identity;
namespace Flight_System_API.Repository.AccountRepository
{
    public interface IAccountRepository
    {
        List<IdentityUser> GetAll();

        Task<IdentityUser> GetById(string userId);
        Task<IdentityResult> UpdateAsync(IdentityUser user);

        Task<IdentityResult> DeleteAsync(string userId);

    }
}
