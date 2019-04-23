using BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIService.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}