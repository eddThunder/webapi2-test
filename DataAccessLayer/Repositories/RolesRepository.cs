using DataAccessLayer.DataModel;
using DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RolesRepository : IRoleRepository
    {
        public RolesRepository(){}

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            using (var ctx = new UsersManagementEntities())
            {
                var roles = await ctx.Roles.ToListAsync();
                return roles;
            }
        }
    }
}
