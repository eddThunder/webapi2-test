using BusinessLayer.Interfaces;
using DataAccessLayer.DataModel;
using DataAccessLayer.Dto;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Mapper;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            var roleList = await _roleDataService.GetAllRoles();

            return FactoryMapper.MapToDto(roleList.ToList());
        }
    }
}
