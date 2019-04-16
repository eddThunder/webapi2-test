
namespace BusinessLayer.Interfaces
{
    using BusinessLayer.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRoleBusiness
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    }
}
