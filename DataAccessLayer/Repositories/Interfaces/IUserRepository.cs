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
        Task<Users> GetByCredentials(string username, string password);
        Task<int> Insert(Users user);
        Task<int> Update(Users user);
        Task<int> Delete(int id);
    }
}
