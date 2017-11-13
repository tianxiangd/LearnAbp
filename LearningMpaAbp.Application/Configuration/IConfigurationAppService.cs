using System.Threading.Tasks;
using Abp.Application.Services;
using LearningMpaAbp.Configuration.Dto;

namespace LearningMpaAbp.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}