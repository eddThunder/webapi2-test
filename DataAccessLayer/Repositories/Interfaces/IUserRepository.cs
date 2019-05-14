using DataAccessLayer.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetByIdAsync(int userId);
        Task<Users> GetByCredentials(string username, string password);
        Task<int> Insert(Users userDto);
        Task<int> Update(Users userDto);
        Task<int> Delete(int id);
    }
}
