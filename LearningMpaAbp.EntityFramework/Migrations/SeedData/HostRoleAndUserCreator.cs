using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using LearningMpaAbp.Authorization;
using LearningMpaAbp.Authorization.Roles;
using LearningMpaAbp.Authorization.Users;
using LearningMpaAbp.EntityFramework;
using Microsoft.AspNet.Identity;

namespace LearningMpaAbp.Migrations.SeedData
{
    public class HostRoleAndUserCreator
    {
        private readonly LearningMpaAbpDbContext _context;

        public HostRoleAndUserCreator(LearningMpaAbpDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            //Admin role for host

            var adminRoleForHost = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.Admin, IsStatic = true });
                _context.SaveChanges();

                //Grant all tenant permissions
                var permissions = PermissionFinder
                    .GetAllPermissions(new LearningMpaAbpAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host))
                    .ToList();
                //task Ȩ��
                var taskPermissions =
                PermissionFinder.GetAllPermissions(new TaskAuthorizationProvider()).ToList();
                permissions.AddRange(taskPermissions);
                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRoleForHost.Id
                        });
                }

                _context.SaveChanges();
            }

            //Admin user for tenancy host

            var adminUserForHost = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == User.AdminUserName);
            if (adminUserForHost == null)
            {
                adminUserForHost = _context.Users.Add(
                    new User
                    {
                        UserName = User.AdminUserName,
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = new PasswordHasher().HashPassword(User.DefaultPassword)
                    });

                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(null, adminUserForHost.Id, adminRoleForHost.Id));

                _context.SaveChanges();
            }
        }
    }
}