using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using poolprobase.Roles.Dto;
using poolprobase.Users.Dto;

namespace poolprobase.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}