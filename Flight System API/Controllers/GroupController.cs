using Flight_System_API.Repository.GroupRepository;
using FlightSystemAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Flight_System_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/groups")]
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public GroupController(IGroupRepository groupRepository,
            UserManager<IdentityUser> userManager,
            FlightContext flightContext)
        {
            _groupRepository = groupRepository;
            _userManager = userManager;

        }
        [HttpGet]
        public IActionResult GetAllGroup()
        {
            List<Group> groups = _groupRepository.GetAll();
            return Ok(groups);
        }
        [HttpGet("{id}")]
        public IActionResult GetGroupById(int id)
        {
            Group group = _groupRepository.GetById(id);
            if (group != null)
            {
                return Ok(group);
            }
            return NotFound($"Group với ID {id} không tồn tại");
        }


        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] Group group)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                group.Creator = currentUser.Email;
            }

            bool created = _groupRepository.CreateGroup(group);
            if (created)
            {
                return Ok(new { Message = "Tạo thành công", Group = group });
            }
            return BadRequest("Tạo không thành công");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGroup(int id, [FromBody] Group group)
        {

            bool Updated = _groupRepository.UpdateGroup(group);
            if (Updated)
            {
                return Ok($"Group với ID {id} Cập nhật thành công");
            }
            return BadRequest($"Cập nhật thất bại");
        }
        [HttpDelete]
        public IActionResult DeleteGroup(int id)
        {
            bool deleted = _groupRepository.DeleteGroup(id);
            if (deleted)
            {
                return Ok("Xóa thành công");
            }
            return BadRequest($"Xóa thất bại");
        }
        [HttpPost("{groupId}/add-member/{memberId}")]
        public async Task<IActionResult> AddMemberToGroup(int groupId, string memberId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null)
            {
                return NotFound($"Group với ID {groupId} không tồn tại");
            }

            var user = await _userManager.FindByIdAsync(memberId);
            if (user == null)
            {
                return NotFound($"Tài khoản có Id {memberId} không tồn tại");
            }

            bool added = _groupRepository.AddMemberToGroup(groupId, user);
            if (added)
            {
                return Ok("Đã thêm thành viên vào Group thành công");
            }
            return BadRequest("Thêm thành viên vào Group thất bại");


        }
        [HttpDelete("{groupId}/remove-member/{memberId}")]
        public async Task<IActionResult> RemoveMemberFromGroup(int groupId, string memberId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null)
            {
                return NotFound($"Không tìm thấy ID {groupId} ");
            }
            var user = await _userManager.FindByIdAsync(memberId);
            if (user == null)
            {
                return NotFound($"Không tìm thấy tài khoản ID {memberId}");
            }
            bool removed = _groupRepository.RemoveMemberFromGroup(groupId, user);

            if (removed)
            {
                return Ok("xóa thành viên khỏi Group thành công");
            }
            return BadRequest("Xóa thành viên khỏi Group thất bại");
        }
    }
}
