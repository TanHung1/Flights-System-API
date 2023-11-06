using FlightSystemAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace Flight_System_API.Repository.GroupRepository
{
    public interface IGroupRepository
    {
        public List<Group> GetAll();

        public Group GetById(int id);
        public bool CreateGroup(Group group);
        public bool UpdateGroup(Group group);
        public bool DeleteGroup(int id);

        public bool AddMemberToGroup(int groupId, IdentityUser user);

        public bool RemoveMemberFromGroup(int groupId, IdentityUser user);
    }
}
