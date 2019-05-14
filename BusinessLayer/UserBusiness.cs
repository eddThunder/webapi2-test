
namespace BusinessLayer
{
    using BusinessLayer.Interfaces;
    using DataAccessLayer;
    using DataAccessLayer.Dto;
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserBusiness : IUserBusiness
    {
        private readonly IUsersData _userService;

        public UserBusiness(IUsersData usersRepository)
        {
            this._userService = usersRepository;
        }

        public async Task<int> DeleteAsync(int userId)
        {
            return await _userService.Delete(userId);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var dtoList = await _userService.GetAllUsersAsync();

            return dtoList;
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            var dto = await _userService.GetById(userId);

            return dto;
        }

        public async Task<UserDto> GetByCredentials(string username, string password)
        {
            var dto = await _userService.GetByCredentials(username, password);

            return dto;
        }

        public async Task<int> Insert(UserDto userDto)
        {
            return await _userService.Insert(userDto);
        }

        public async Task<int> Update(UserDto userDto)
        {
           return await _userService.Update(userDto);
        }
    }
}
