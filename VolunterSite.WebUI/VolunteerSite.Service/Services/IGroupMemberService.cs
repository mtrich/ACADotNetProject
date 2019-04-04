using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;
using VolunteerSite.Data.Interfaces;

namespace VolunteerSite.Service.Services
{
    public interface IGroupMemberService
    {
        GroupMember GetById(int groupMemberId);
        ICollection<GroupMember> GetByGroupId(string volunteerGroupId);
        GroupMember Create(GroupMember newGroupMember);
        GroupMember Update(GroupMember UpdatedGroupMember);
        bool DeleteById(int groupMemberId);
    }
    public class GroupMemberService : IGroupMemberService
    {
        private readonly IGroupMemberRepository _groupMemberRepository;

        public GroupMemberService(IGroupMemberRepository groupMemberRepository)
        {
            _groupMemberRepository = groupMemberRepository;
        }

        public GroupMember Create(GroupMember newGroupMember)
        {
            return _groupMemberRepository.Create(newGroupMember);
        }

        public bool DeleteById(int groupMemberId)
        {
            return _groupMemberRepository.DeleteById(groupMemberId);
        }

        public ICollection<GroupMember> GetByGroupId(string volunteerGroupId)
        {
            return _groupMemberRepository.GetByGroupId(volunteerGroupId);
        }

        public GroupMember GetById(int groupMemberId)
        {
            return _groupMemberRepository.GetById(groupMemberId);
        }

        public GroupMember Update(GroupMember UpdatedGroupMember)
        {
            return _groupMemberRepository.Update(UpdatedGroupMember);
        }
    }
}
