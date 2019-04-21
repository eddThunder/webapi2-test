using DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersWebAPI.Test.Builders
{
    public class RoleBuilder
    {
        private Roles role;

        public RoleBuilder()
        {
            role = new Roles();
        }

        public RoleBuilder WithName(string nombre)
        {
            role.RoleName = nombre;
            return this;
        }

        public RoleBuilder WithId(int id)
        {
            role.Id = id;
            return this;
        }

        public Roles Build()
        {
            return role;
        }
    }
}
