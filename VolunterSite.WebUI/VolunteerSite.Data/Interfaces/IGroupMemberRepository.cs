using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Interfaces
{
    public interface IGroupMemberRepository
    {
        //read
        GroupMember GetById(int groupMemberId);
        ICollection<GroupMember> GetByGroupId(int groupId);

        //create
        GroupMember Create(GroupMember newGroupMember);

        //Update
        GroupMember Update(GroupMember UpdatedGroupMember);

        //Delete
        bool DeleteById(int groupMemberId);
    }
}
