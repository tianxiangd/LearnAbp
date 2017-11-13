using System.Collections.Generic;
using LearningMpaAbp.Roles.Dto;
using LearningMpaAbp.Users.Dto;

namespace LearningMpaAbp.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}