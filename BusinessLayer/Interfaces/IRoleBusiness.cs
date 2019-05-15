using DataAccessLayer.DataModel;
using DataAccessLayer.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IRoleBusiness
    {
        Task<IEnumerable<Roles>> GetAllRoles();
    }
}
