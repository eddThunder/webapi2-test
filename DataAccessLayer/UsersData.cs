
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

        public async Task Insert(Users user)
        {
            await _userRepository.Insert(user);
        }

        public async Task Update(Users user)
        {
            await _userRepository.Update(user);
        }

        public async Task Delete(int EmployeeID)
        {
            throw new NotImplementedException();
        }
    }
}
