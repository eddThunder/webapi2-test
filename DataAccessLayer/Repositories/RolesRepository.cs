﻿using DataAccessLayer.DataModel;
using DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RolesRepository : IRoleRepository
    {
        private readonly UsersManagementEntities _context;

        public RolesRepository()
        {
            _context = new UsersManagementEntities();
        }

        public RolesRepository(UsersManagementEntities context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}