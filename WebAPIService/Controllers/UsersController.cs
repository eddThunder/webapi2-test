﻿

namespace WebAPIService.Controllers
{
    using BusinessLayer.Dto;
    using BusinessLayer.Interfaces;
    using DataAccessLayer.DataModel;
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserBusiness _userBusinessService;
        // private readonly ILogger _logger;

        public UsersController(IUserBusiness userBusinessService)
        {
            _userBusinessService = userBusinessService;
            //_logger = logger;
        }
        
        [HttpGet]
        [Route("all")]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userBusinessService.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                //_logger.LogError("error in UsersController -> GetAllUsersAsync: ", ex);
                throw;
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IHttpActionResult> GetUserById(int userId)
        {
            try
            {
                return Ok(await _userBusinessService.GetByIdAsync(userId));
            }
            catch(Exception ex)
            {
                //_logger.LogError("error in UsersController -> GetUserById: ", ex);
                throw;
            }
        }

        [HttpPut]
        [Route("add")]
        public void InsertUser(UserDto user)
        {
            try
            {
                _userBusinessService.Insert(user);
            }
            catch (Exception ex)
            {
                //Logger...
                throw;
            }
        }

        [HttpPut]
        [Route("update")]
        public void UpdateUser(UserDto user)
        {
            try
            {
                _userBusinessService.Update(user);
            }
            catch (Exception ex)
            {
                //Logger...
                throw;
            }
        }
    }
}