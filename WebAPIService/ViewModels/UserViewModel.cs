using DataAccessLayer.Dto;
using System.Collections.Generic;

namespace WebAPIService.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}