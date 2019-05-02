
namespace BusinessLayer
{
    using BusinessLayer.Dto;
    using BusinessLayer.Interfaces;
    using BusinessLayer.Mapper;
    using DataAccessLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserBusiness : IUserBusiness
    {
        private readonly IUsersData _usersDataService;

        public UserBusiness(IUsersData usersDataService)
        {
            this._usersDataService = usersDataService;
        }

        public async Task<int> DeleteAsync(int userId)
        {
            return await _usersDataService.Delete(userId);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var entityList = await _usersDataService.GetAllUsersAsync();

            var dtoList = FactoryMapper.MapToDto(entityList.ToList());

            return dtoList;
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            var entity = await _usersDataService.GetById(userId);

            var resultDto = FactoryMapper.MapToDtoWithPassword(entity);
            
            return resultDto;
        }

        public async Task<UserDto> GetByCredentials(string username, string password)
        {
            var entity = await _usersDataService.GetByCredentials(username, password);

            var resultDto = FactoryMapper.MapToDto(entity);

            return resultDto;
        }

        public async Task<int> Insert(UserDto userDto)
        {
            var entity = FactoryMapper.MapToEntity(userDto);

            return await _usersDataService.Insert(entity);
        }

        public async Task<int> Update(UserDto userDto)
        {
           var entity = FactoryMapper.MapToEntity(userDto);

           return await _usersDataService.Update(entity);
        }
    }
}
