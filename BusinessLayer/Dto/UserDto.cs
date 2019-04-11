using System.Collections.Generic;

namespace BusinessLayer.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
