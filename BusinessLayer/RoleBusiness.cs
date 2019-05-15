using BusinessLayer.Interfaces;
using DataAccessLayer.DataModel;
using DataAccessLayer.Dto;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RoleBusiness : IRoleBusiness
    {
        private readonly IRoleData _roleDataService;

        public RoleBusiness(IRoleData roleDataService)
        {
            _roleDataService = roleDataService;
        }

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            var roleList = await _roleDataService.GetAllRoles();

            return roleList;
        }
    }
}
