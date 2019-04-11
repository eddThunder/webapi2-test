
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

        public void Delete(UserDto user)
        {
            throw new NotImplementedException();
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
            var resultDto = FactoryMapper.MapToDto(entity);
            
            return resultDto;
        }

        public void Insert(UserDto userDto)
        {
            var entity = FactoryMapper.MapToEntity(userDto);
            _usersDataService.Insert(entity);
        }

        public void Update(UserDto userDto)
        {
            var entity = FactoryMapper.MapToEntity(userDto);
            _usersDataService.Update(entity);
        }
    }
}
