using System.Collections.Generic;
using poolprobase.Roles.Dto;
using poolprobase.Users.Dto;

namespace poolprobase.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}