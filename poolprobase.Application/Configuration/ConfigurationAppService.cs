using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using poolprobase.Configuration.Dto;

namespace poolprobase.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : poolprobaseAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
