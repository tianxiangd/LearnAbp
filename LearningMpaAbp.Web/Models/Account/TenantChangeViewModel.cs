using Abp.AutoMapper;
using LearningMpaAbp.Sessions.Dto;

namespace LearningMpaAbp.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}