

namespace BusinessLayer.Interfaces
{
    using BusinessLayer.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserBusiness
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetByIdAsync(int userId);
        Task Insert(UserDto user);
        Task Update(UserDto user);
        void Delete(UserDto user);
    }
}
