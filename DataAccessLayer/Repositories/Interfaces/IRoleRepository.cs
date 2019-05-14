using DataAccessLayer.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Roles>> GetAllRoles();
    }
}
