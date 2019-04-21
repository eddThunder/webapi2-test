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

        public UserBuilder WithId(int id)
        {
            user.Id = id;
            return this;
        }

        public UserBuilder WithUsername(string username)
        {
            user.Username = username;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            user.UserPassword = password;
            return this;
        }

        public UserBuilder WithRoles(List<UsersRoles> roles)
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
