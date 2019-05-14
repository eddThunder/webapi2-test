
namespace DataAccessLayer
{
    using DataAccessLayer.Dto;
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Mapper;
    using DataAccessLayer.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersData : IUsersData
    {
        private readonly IUserRepository _userRepository;
        public UsersData(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {

            var userList = await _userRepository.GetAllUsersAsync();

            return FactoryMapper.MapToDto(userList.ToList());
        }

        public async Task<UserDto> GetById(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            return FactoryMapper.MapToDto(user);
        }

        public async Task<int> Insert(UserDto userDto)
        {
            var user = FactoryMapper.MapToEntity(userDto);

            return await _userRepository.Insert(user);
        }

        public async Task<int> Update(UserDto userDto)
        {
            var user = FactoryMapper.MapToEntity(userDto);

            return await _userRepository.Update(user);
        }

        public async Task<int> Delete(int userId)
        {
            return await _userRepository.Delete(userId);
        }

        public async Task<UserDto> GetByCredentials(string username, string password)
        {
            var user = await _userRepository.GetByCredentials(username, password);

            return FactoryMapper.MapToDto(user);
        }
    }
}
