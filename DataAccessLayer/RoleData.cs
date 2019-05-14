using DataAccessLayer.DataModel;
using DataAccessLayer.Dto;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Mapper;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleData : IRoleData
    {
        private readonly IRoleRepository _roleRepository;
        public RoleData(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            var roles = await this._roleRepository.GetAllRoles();

            return FactoryMapper.MapToDto(roles.ToList());
        }
    }
}
