

namespace BusinessLayer.Interfaces
{
    using BusinessLayer.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserBusiness
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetByIdAsync(int userId);
        void Insert(UserDto user);
        void Update(UserDto user);
        void Delete(UserDto user);
    }
}
