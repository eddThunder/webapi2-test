
namespace BusinessLayer
{
    using BusinessLayer.Interfaces;
    using DataAccessLayer.DataModel;
    using DataAccessLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserBusiness : IUserBusiness
    {
        private readonly IUsersData _usersDataService;
        public UserBusiness(IUsersData usersDataService)
        {
            this._usersDataService = usersDataService;
        }

        public void Delete(Users user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _usersDataService.GetAllUsersAsync();
        }

        public async Task<Users> GetByIdAsync(int userId)
        {
            return await _usersDataService.GetById(userId);
        }

        public void Insert(Users user)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(Users user)
        {
            _usersDataService.Insert(user);
        }

        public void Update(Users user)
        {
            _usersDataService.Update(user);
        }
    }
}
