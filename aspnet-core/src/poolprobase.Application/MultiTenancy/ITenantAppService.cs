using Abp.Application.Services;
using Abp.Application.Services.Dto;
using poolprobase.MultiTenancy.Dto;

namespace poolprobase.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
