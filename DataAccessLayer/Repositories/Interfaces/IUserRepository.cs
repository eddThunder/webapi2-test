using DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetByIdAsync(int userId);
        Task Insert(Users user);
        Task Update(Users user);
        Task Delete(int id);
        Task Save();
        void Dispose();
    }
}
