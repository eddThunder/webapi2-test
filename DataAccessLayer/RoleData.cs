using DataAccessLayer.DataModel;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            var roles = await this._roleRepository.GetAllRoles();

            return roles;
        }
    }
}
