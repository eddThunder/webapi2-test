

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

        //public UserRepository()
        //{
        //    _context = new UsersManagementEntities();
        //}


        public UserRepository(UsersManagementEntities context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            try
            {
                using (UsersManagementEntities rm = new UsersManagementEntities())
                {
                    var ar= await rm.Users.Include(x => x.UsersRoles).ToListAsync();
                    foreach (var item in ar)
                    {
                        if (item.UsersRoles.Any())
                        {
                            var urs = await rm.UsersRoles.Where(x => x.UserId == item.Id).Include(x => x.Roles).ToListAsync();
                            item.UsersRoles = new List<UsersRoles>(urs);
                        }
                    }
                    return ar;
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
                using (UsersManagementEntities rm = new UsersManagementEntities())
                {
                    var result = await rm.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

                    if (result.UsersRoles.Any() || result.UsersRoles == null)
                    {
                        var urs = await rm.UsersRoles.Where(x => x.UserId == userId).Include(x=> x.Roles).ToListAsync();
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

        public async Task<IEnumerable<Roles>> GetRolesByUserId(int userId)
        {
            //
            return null;
        }



        public async Task<int> Insert(Users user)
        {
            try
            {
                using (UsersManagementEntities rm = new UsersManagementEntities())
                {
                    rm.Entry<Users>(user).State = EntityState.Added;

                    var resultUpdate = await rm.SaveChangesAsync();

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
                    using (UsersManagementEntities rm = new UsersManagementEntities())
                    {
                        var userEntity = await rm.Set<Users>().FindAsync(user.Id);
                        if (userEntity != null)
                        {
                            //rm.Set<Users>().Attach(user);
                            userEntity.UsersRoles = new List<UsersRoles>();
                            userEntity.UsersRoles = user.UsersRoles;
                            rm.Entry<Users>(userEntity).State = EntityState.Modified;

                            var resultUpdate = await rm.SaveChangesAsync();

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
                using (UsersManagementEntities rm = new UsersManagementEntities())
                {
                    var user = await rm.Users.FindAsync(userId);

                    _context.Entry<Users>(user).State = EntityState.Deleted;
                    rm.Set<Users>().Attach(user);
                    rm.Set<Users>().Remove(user);
                    return await rm.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private async Task<int> DeleteUserRoles(int userId)
        {
            try
            {
                using (UsersManagementEntities rm = new UsersManagementEntities())
                {
                    var usersRolesToDelete = rm.UsersRoles.Where(x => x.UserId == userId).ToList();

                    if (!usersRolesToDelete.Any()) return 0;

                    foreach (var item in usersRolesToDelete)
                    {
                        rm.Set<UsersRoles>().Attach(item);
                    }
                    rm.Set<UsersRoles>().RemoveRange(usersRolesToDelete);

                    return await rm.SaveChangesAsync();
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
                using (UsersManagementEntities rm = new UsersManagementEntities())
                {
                    var result = await rm.Users.Where(x => x.Username == username && x.UserPassword == password).FirstOrDefaultAsync();

                    if (result.UsersRoles.Any())
                    {
                        var urs = await rm.UsersRoles.Where(x => x.UserId == result.Id).Include(x => x.Roles).ToListAsync();
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
