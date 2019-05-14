using DataAccessLayer.DataModel;
using DataAccessLayer.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRoleData
    {
        Task<IEnumerable<RoleDto>> GetAllRoles();
    }
}
