using Flight_System_API.Models;
using Flight_System_API.Repository.AccountRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flight_System_API.Controllers
{

    [ApiController]
    [Route("api/controller")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(IAccountRepository accountRepository, UserManager<IdentityUser> userManager)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult Get()
        {
            List<IdentityUser> users = _accountRepository.GetAll();
            return Ok(users);
        }
        [HttpGet]
        [Route("get/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var user = await _accountRepository.GetById(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpPut]
        [Route("update/{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] IdentityUser model)
        {
            var user = await _accountRepository.GetById(userId);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName; // Cập nhật tên người dùng
            user.Email = model.Email; // Cập nhật email
            user.PhoneNumber = model.PhoneNumber; // Cập nhật số điện thoại


            var result = await _accountRepository.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(new { Status = "Success", Message = "Cập nhật thông tin tài khoản thành công" });
            }

            return StatusCode(StatusCodes.Status500InternalServerError,
                new { Status = "Error", Message = "Cập nhật thông tin tài khoản thất bại" });
        }
        [HttpPut]
        [Route("update-roles")]
        public async Task<IActionResult> UpdateUserRole(string username, List<string> roles)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound("Không tìm thấy tài khoản");
            }
            var userRoles = await _userManager.GetRolesAsync(user);

            //xóa người dùng khỏi vai trò đang có
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            //thêm người dùng vào vai trò mới 
            var result = await _userManager.AddToRolesAsync(user, roles);
            if (result.Succeeded)
            {
                return Ok(new Response { Status = "Thành công", Message = "Cập nhật vai trò thành công" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Lỗi", Message = "Lỗi khi cập nhật vai trò" });

            }

        }
        [HttpDelete]
        [Route("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var result = await _accountRepository.DeleteAsync(userId);
            if (result.Succeeded)
            {
                return Ok(new { Status = "Thành công", Message = "Xóa thành công" });

            }
            return BadRequest(new { Status = "Lỗi", Message = "Xóa thất bại" });
        }
    }
}
