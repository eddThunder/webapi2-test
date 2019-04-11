using DataAccessLayer.DataModel;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
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

        public void Insert(Users user)
        {
            try
            {
                _context.Entry<Users>(user).State = EntityState.Added;
                Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Users user)
        {
            try
            {
                _context.Entry<Users>(user).State = EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Users user)
        {
            try
            {
                _context.Entry<Users>(user).State = EntityState.Deleted;
                Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
