using DataAccessLayer.DataModel;
using System.Collections.Generic;

namespace UsersWebAPI.Test.Builders
{
    public class UserBuilder
    {
        private Users user;

        public UserBuilder()
        {
            user = new Users();
        }

        public UserBuilder ConId(int id)
        {
            user.Id = id;
            return this;
        }

        public UserBuilder ConUsername(string username)
        {
            user.Username = username;
            return this;
        }

        public UserBuilder ConPassword(string password)
        {
            user.UserPassword = password;
            return this;
        }

        public UserBuilder ConRoles(List<UsersRoles> roles)
        {
            user.UsersRoles = roles;
            return this;
        }

        public Users Build()
        {
            return user;
        }
    }
}
