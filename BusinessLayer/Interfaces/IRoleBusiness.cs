using BusinessLayer.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IRoleBusiness
    {
        Task<IEnumerable<RoleDto>> GetAllRoles();
    }
}
