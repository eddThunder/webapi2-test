

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

        public UserRepository()
        {
            _context = new UsersManagementEntities();
        }

        public UserRepository(UsersManagementEntities context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
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
                return await _context.Users.FindAsync(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(Users user)
        {
            try
            {
                _context.Entry<Users>(user).State = EntityState.Added;
                await Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(Users user)
        {
            try
            {
                var userEntity = await GetByIdAsync(user.Id);

                _context.Entry<Users>(userEntity).CurrentValues.SetValues(user);
              
                _context.Entry<Users>(userEntity).State = EntityState.Modified;

                await DeleteUserRoles(user.Id);

                userEntity.UsersRoles = user.UsersRoles.ToList();

                await Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);

                _context.Entry<Users>(user).State = EntityState.Deleted;

                await Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private async Task DeleteUserRoles(int userId)
        {
            try
            {
                var usersRolesToDelete = _context.UsersRoles.Where(x => x.UserId == userId).ToList();

                _context.UsersRoles.RemoveRange(usersRolesToDelete);

                await Save();

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
                var user = await _context.Users.Where(x => x.Username == username && x.UserPassword == password).FirstOrDefaultAsync();

                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
