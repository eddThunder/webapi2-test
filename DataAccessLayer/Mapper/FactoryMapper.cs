

namespace DataAccessLayer.Mapper
{
    using DataAccessLayer.DataModel;
    using DataAccessLayer.Dto;
    using System.Collections.Generic;
    using System.Linq;

    public static class FactoryMapper
    {

        /// <summary>
        /// Map user Users to a dto object
        /// </summary>
        /// <param name="user"></param>
        /// <returns>UserDto</returns>
        public static UserDto MapToDto(Users user)
        {
            var dto = new UserDto();
            dto.Id = user.Id;
            dto.UserName = user.Username;
            dto.Roles = MapToDto(user.UsersRoles.ToList());

            return dto;
        }

        /// <summary>
        /// Map user Users to a dto object with password
        /// </summary>
        /// <param name="user"></param>
        /// <returns>UserDto</returns>
        public static UserDto MapToDtoWithPassword(Users user)
        {
            var dto = new UserDto();
            dto.Id = user.Id;
            dto.UserName = user.Username;
            dto.Password = user.UserPassword;
            dto.Roles = MapToDto(user.UsersRoles.ToList());

            return dto;
        }

        /// <summary>
        /// Map a list of User entities to a list of UserDto
        /// </summary>
        /// <param name="users"></param>
        /// <returns> List<UserDto></returns>
        public static List<UserDto> MapToDto(List<Users> users)
        {
            var dtoList = new List<UserDto>();

            if (users.Any())
            {
                users.ForEach(user => dtoList.Add(new UserDto
                {
                    Id = user.Id,
                    UserName = user.Username,
                    Roles = MapToDto(user.UsersRoles.ToList())
                }));
            }

            return dtoList;
        }

        /// <summary>
        /// Map a list of UsersRoles to a List of RoleDto
        /// </summary>
        /// <param name="roles"></param>
        /// <returns>List<RoleDto></returns>
        public static List<RoleDto> MapToDto(List<UsersRoles> roles)
        {
            var dtoList = new List<RoleDto>();

            if (roles.Any())
            {
                roles.ForEach(role => dtoList.Add(new RoleDto
                {
                    Id = role.RoleId,
                    RoleName = role.Roles.RoleName
                }));
            }

            return dtoList;
        }

        /// <summary>
        /// Map a list of Roles to RolesDto
        /// </summary>
        /// <param name="rolesList"></param>
        /// <returns></returns>
        public static List<RoleDto> MapToDto(List<Roles> rolesList)
        {
            var dtoList = new List<RoleDto>();

            if (rolesList.Any())
            {
                rolesList.ForEach(role => dtoList.Add(new RoleDto
                {
                    Id = role.Id,
                    RoleName = role.RoleName
                }));
            }
            return dtoList;
        }

        /// <summary>
        /// Map a UserDto to a Users entity
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Users MapToEntity(UserDto dto)
        {
            var entity = new Users();
            entity.Id = dto.Id;
            entity.Username = dto.UserName;
            entity.UserPassword = dto.Password;
            entity.UsersRoles = MapToEntity(dto.Roles.ToList(), entity.Id);

            return entity;
        }

        /// <summary>
        /// Map a related  user's RoleDto list to a IColletion of UsersRoles
        /// </summary>
        /// <param name="rolesDto"></param>
        /// <param name="userId"></param>
        /// <returns>ICollection<UsersRoles></returns>
        public static ICollection<UsersRoles> MapToEntity(List<RoleDto> rolesDto, int userId)
        {
            var entityRoleList = new List<UsersRoles>();

            if (rolesDto.Any())
            {
                rolesDto.ForEach(dto => entityRoleList.Add(new UsersRoles {
                    RoleId = dto.Id,
                    UserId = userId
                }));
            }

            return entityRoleList;
        }


    }
}
