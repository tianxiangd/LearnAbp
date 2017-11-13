using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LearningMpaAbp.Configuration.Dto;

namespace LearningMpaAbp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LearningMpaAbpAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
