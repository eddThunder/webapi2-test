using BusinessLayer.Dto;
using BusinessLayer.Interfaces;
using BusinessLayer.Mapper;
using DataAccessLayer.Interfaces;
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

            var dtoList = FactoryMapper.MapToDto(roleList.ToList());

            return dtoList;
        }
    }
}
