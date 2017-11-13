using System.Collections.Generic;
using LearningMpaAbp.Roles.Dto;

namespace LearningMpaAbp.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}