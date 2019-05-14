

namespace DataAccessLayer.Interfaces
{
    using DataAccessLayer.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersData
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetById(int userId);
        Task<UserDto> GetByCredentials(string username, string password);
        Task<int> Insert(UserDto user);
        Task<int> Update(UserDto user);
        Task<int> Delete(int EmployeeID);
    }
}
