using Abp.Authorization;
using LearningMpaAbp.Authorization.Roles;
using LearningMpaAbp.Authorization.Users;

namespace LearningMpaAbp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
