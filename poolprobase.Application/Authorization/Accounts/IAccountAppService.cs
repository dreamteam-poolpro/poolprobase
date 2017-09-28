using System.Threading.Tasks;
using Abp.Application.Services;
using poolprobase.Authorization.Accounts.Dto;

namespace poolprobase.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
