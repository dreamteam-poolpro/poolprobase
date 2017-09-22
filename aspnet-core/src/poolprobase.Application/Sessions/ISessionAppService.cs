using System.Threading.Tasks;
using Abp.Application.Services;
using poolprobase.Sessions.Dto;

namespace poolprobase.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
