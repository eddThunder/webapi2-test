
namespace DataAccessLayer
{
    using DataAccessLayer.DataModel;
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Repositories.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsersData : IUsersData
    {
        private readonly IUserRepository _userRepository;
        public UsersData(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<Users> GetById(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<int> Insert(Users user)
        {
            return await _userRepository.Insert(user);
        }

        public async Task<int> Update(Users user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<int> Delete(int userId)
        {
            return await _userRepository.Delete(userId);
        }

        public async Task<Users> GetByCredentials(string username, string password)
        {
            return await _userRepository.GetByCredentials(username, password);
        }
    }
}
