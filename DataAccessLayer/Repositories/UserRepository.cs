

namespace DataAccessLayer.Repositories
{
    using DataAccessLayer.DataModel;
    using DataAccessLayer.Repositories.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private readonly UsersManagementEntities _context;

        public UserRepository(UsersManagementEntities context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            try
            {
                using (UsersManagementEntities ctx = new UsersManagementEntities())
                {
                    var users= await ctx.Users.Include(x => x.UsersRoles).ToListAsync();
                    foreach (var item in users)
                    {
                        if (item.UsersRoles.Any())
                        {
                            var userRoles = await ctx.UsersRoles.Where(x => x.UserId == item.Id).Include(x => x.Roles).ToListAsync();
                            item.UsersRoles = new List<UsersRoles>(userRoles);
                        }
                    }

                    return users;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> GetByIdAsync(int userId)
        {
            try
            {
                using (UsersManagementEntities ctx = new UsersManagementEntities())
                {
                    var result = await ctx.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

                    if (result.UsersRoles.Any() || result.UsersRoles == null)
                    {
                        var userRoles = await ctx.UsersRoles.Where(x => x.UserId == userId).Include(x=> x.Roles).ToListAsync();
                        result.UsersRoles = new List<UsersRoles>(userRoles);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Insert(Users user)
        {
            try
            {
                using (UsersManagementEntities ctx = new UsersManagementEntities())
                {
                    ctx.Entry<Users>(user).State = EntityState.Added;

                    var resultUpdate = await ctx.SaveChangesAsync();

                    return resultUpdate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(Users user)
        {
            try
            {
                var resultDeleteRoles = await DeleteUserRoles(user.Id);

                if (resultDeleteRoles != 0)
                {
                    using (UsersManagementEntities ctx = new UsersManagementEntities())
                    {
                        var userEntity = await ctx.Set<Users>().FindAsync(user.Id);
                        if (userEntity != null)
                        {
                            ctx.Entry<Users>(userEntity).CurrentValues.SetValues(user);
                            userEntity.UsersRoles = new List<UsersRoles>();
                            userEntity.UsersRoles = user.UsersRoles;
                            ctx.Entry<Users>(userEntity).State = EntityState.Modified;

                            var resultUpdate = await ctx.SaveChangesAsync();

                            return resultUpdate;
                        }
                    }
                    return 0;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int userId)
        {
            try
            {
                using (UsersManagementEntities ctx = new UsersManagementEntities())
                {
                    var user = await ctx.Users.FindAsync(userId);

                    if(user != null)
                    {
                        await DeleteUserRoles(user.Id);
                        ctx.Set<Users>().Attach(user);
                        ctx.Set<Users>().Remove(user);

                        return await ctx.SaveChangesAsync();
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<int> DeleteUserRoles(int userId)
        {
            try
            {
                using (UsersManagementEntities ctx = new UsersManagementEntities())
                {
                    var usersRolesToDelete = ctx.UsersRoles.Where(x => x.UserId == userId).ToList();

                    if (!usersRolesToDelete.Any()) return 0;

                    foreach (var item in usersRolesToDelete)
                    {
                        ctx.Set<UsersRoles>().Attach(item);
                    }
                    ctx.Set<UsersRoles>().RemoveRange(usersRolesToDelete);

                    return await ctx.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> GetByCredentials(string username, string password)
        {
            try
            {
                using (UsersManagementEntities ctx = new UsersManagementEntities())
                {
                    var result = await ctx.Users.Where(x => x.Username == username && x.UserPassword == password).FirstOrDefaultAsync();

                    if (result.UsersRoles.Any())
                    {
                        var urs = await ctx.UsersRoles.Where(x => x.UserId == result.Id).Include(x => x.Roles).ToListAsync();
                        result.UsersRoles = new List<UsersRoles>(urs);
                    }

                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
