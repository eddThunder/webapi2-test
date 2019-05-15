

namespace DataAccessLayer.Interfaces
{
    using DataAccessLayer.DataModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersData
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetById(int userId);
        Task<Users> GetByCredentials(string username, string password);
        Task<int> Insert(Users user);
        Task<int> Update(Users user);
        Task<int> Delete(int EmployeeID);
    }
}
