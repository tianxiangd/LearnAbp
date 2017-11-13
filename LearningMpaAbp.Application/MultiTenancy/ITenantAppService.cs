using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LearningMpaAbp.MultiTenancy.Dto;

namespace LearningMpaAbp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
