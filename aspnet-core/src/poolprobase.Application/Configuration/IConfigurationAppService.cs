using System.Threading.Tasks;
using poolprobase.Configuration.Dto;

namespace poolprobase.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}