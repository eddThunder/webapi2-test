

namespace DataAccessLayer.Interfaces
{
    using DataAccessLayer.DataModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersData
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetById(int userId);
        Task Insert(Users user);
        Task Update(Users user);
        Task Delete(int EmployeeID);
    }
}
