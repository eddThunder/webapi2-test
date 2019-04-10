

namespace BusinessLayer.Interfaces
{
    using DataAccessLayer.DataModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserBusiness
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetByIdAsync(int userId);
        void Insert(Users user);
        void Update(Users user);
        void Delete(Users user);
    }
}
