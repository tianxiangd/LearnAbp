using System.Threading.Tasks;
using Abp.Application.Services;
using LearningMpaAbp.Authorization.Accounts.Dto;

namespace LearningMpaAbp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
