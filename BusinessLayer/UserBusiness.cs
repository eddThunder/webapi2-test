﻿
namespace BusinessLayer
{
    using BusinessLayer.Interfaces;
    using DataAccessLayer.Dto;
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Mapper;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserBusiness : IUserBusiness
    {
        private readonly IUsersData _userService;

        public UserBusiness(IUsersData userService)
        {
            this._userService = userService;
        }

        public async Task<int> DeleteAsync(int userId)
        {
            return await _userService.Delete(userId);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var entityList = await _userService.GetAllUsersAsync();

            return FactoryMapper.MapToDto(entityList.ToList());
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            var entity = await _userService.GetById(userId);

            return FactoryMapper.MapToDtoWithPassword(entity);
        }

        public async Task<UserDto> GetByCredentials(string username, string password)
        {
            var entity = await _userService.GetByCredentials(username, password);

            return FactoryMapper.MapToDto(entity);
        }

        public async Task<int> Insert(UserDto userDto)
        {
            var entity = FactoryMapper.MapToEntity(userDto);

            return await _userService.Insert(entity);
        }

        public async Task<int> Update(UserDto userDto)
        {
            var entity = FactoryMapper.MapToEntity(userDto);

            return await _userService.Update(entity);
        }
    }
}
