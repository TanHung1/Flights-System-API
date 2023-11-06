using FlightSystemAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace Flight_System_API.Repository.GroupRepository
{
    public class GroupRepository : IGroupRepository
    {
        private FlightContext _context;
        public GroupRepository(FlightContext context)
        {
            _context = context;
        }

        public bool AddMemberToGroup(int groupId, IdentityUser user)
        {
            var group = _context.Groups.FirstOrDefault(x => x.GroupId == groupId);
            if (group == null)
            {
                return false;
            }
            group.Members.Add(user);
            group.Member++;
            _context.SaveChanges();
            return true;
        }
        public bool RemoveMemberFromGroup(int groupId, IdentityUser user)
        {
            var group = _context.Groups.FirstOrDefault(x => x.GroupId == groupId);
            if (group == null)
            {
                return false;
            }
            group.Members.Remove(user);
            group.Member--;
            _context.SaveChanges();
            return true;
        }

        public bool CreateGroup(Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteGroup(int id)
        {
            Group group = _context.Groups.FirstOrDefault(x => x.GroupId == id);
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return true;
        }

        public List<Group> GetAll()
        {
            return _context.Groups.ToList();
        }

        public Group GetById(int id)
        {
            Group group = _context.Groups.FirstOrDefault(x => x.GroupId == id);
            return group;
        }


        public bool UpdateGroup(Group group)
        {
            Group group1 = _context.Groups.FirstOrDefault(x => x.GroupId == group.GroupId);
            if (group1 != null)
            {
                _context.Entry(group1).CurrentValues.SetValues(group);
                _context.SaveChanges();
            }
            return true;
        }
    }
}
