using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Events.Bus.Exceptions;
using Abp.Events.Bus.Handlers;
using Abp.UI;
using Abp.Web.Mvc.Authorization;
using LearningMpaAbp.Authorization;
using LearningMpaAbp.Authorization.Roles;
using LearningMpaAbp.Users;
using LearningMpaAbp.Web.Models.Users;
using LearningMpaAbp.Users.Dto;
using X.PagedList;

namespace LearningMpaAbp.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : LearningMpaAbpControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly RoleManager _roleManager;

        public UsersController(IUserAppService userAppService, RoleManager roleManager)
        {
            _userAppService = userAppService;
            _roleManager = roleManager;
        }

        public async Task<ActionResult> Index()
        {
            
            var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = 10 })).Items; //Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Users = users,
                Roles = roles
            };

            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View("_EditUserModal", model);
        }
        // GET: Tasks
        public ActionResult PagedList(int? page)
        {
            //每页行数
            var pageSize = 5;
            var pageNumber = page ?? 1; //第几页

            var filter = new GetUsersDto
            {
                SkipCount = (pageNumber - 1) * pageSize, //忽略个数
                MaxResultCount = pageSize
            };
            var result = _userAppService.GetPagedUsers(filter);

            // var result = _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = 10, SkipCount = pageNumber }); //Paging not implemented yet

            var onePageOfUsers = new StaticPagedList<UserDto>(result.Items, pageNumber, pageSize, result.TotalCount);
            //将分页结果放入ViewBag供View使用
            ViewBag.OnePageOfUsers = onePageOfUsers;

            return View();
        }
    }
}