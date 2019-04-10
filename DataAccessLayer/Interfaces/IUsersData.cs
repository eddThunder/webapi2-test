

namespace DataAccessLayer.Interfaces
{
    using DataAccessLayer.DataModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersData
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetById(int userId);
        void Insert(Users user);
        void Update(Users user);
        void Delete(int EmployeeID);
    }
}
