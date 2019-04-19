using DataAccessLayer.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRoleData
    {
        Task<IEnumerable<Roles>> GetAllRoles();
    }
}
