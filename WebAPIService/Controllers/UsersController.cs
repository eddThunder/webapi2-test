

namespace WebAPIService.Controllers
{
    using BusinessLayer.Dto;
    using BusinessLayer.Interfaces;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Http;
    using WebAPIService.ViewModels;

    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserBusiness _userBusinessService;
        private readonly IRoleBusiness _roleBusiness;

        private readonly ILog _logger;

        public UsersController(IUserBusiness userBusinessService, ILog logger, IRoleBusiness roleBusiness)
        {
            _userBusinessService = userBusinessService;
            _roleBusiness = roleBusiness;
            _logger = logger;
        }
        
        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userBusinessService.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                _logger.Error("error in UsersController -> GetAllUsersAsync: ", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{userId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IHttpActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await _userBusinessService.GetByIdAsync(userId);

                if(user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch(Exception ex)
            {
                _logger.Error("error in UsersController -> GetUserById: ", ex);
                return BadRequest( ex.Message);
            }
        }

        [HttpPut]
        [Route("add")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IHttpActionResult> InsertUser(UserDto user)
        {
            try
            {
               return Ok(await _userBusinessService.Insert(user));
            }
            catch (Exception ex)
            {
                _logger.Error("error in UsersController -> InsertUser: ", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IHttpActionResult> UpdateUserAsync(UserDto user)
        {
            try
            {
                return Ok(await _userBusinessService.Update(user));
            }
            catch (Exception ex)
            {
                _logger.Error("error in UsersController -> UpdateUserAsync: ", ex);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("delete/{userId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IHttpActionResult> DeleteUser(int userId)
        {
            try
            {
                return Ok(await _userBusinessService.DeleteAsync(userId));
            }
            catch(Exception ex)
            {
                _logger.Error("error in UsersController -> DeleteUser: ", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("claims")]
        public async Task<UserViewModel> GetUserClaims()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var allRoles = await _roleBusiness.GetAllRoles();
            var rolesClaim = identity.FindAll(ClaimTypes.Role).ToList();

            var roles = new List<RoleDto>();

            rolesClaim.ForEach(claim => roles.Add(new RoleDto
            {
                Id = allRoles.Where(x => x.RoleName == claim.Value).First().Id,
                RoleName = claim.Value
            }));


            UserViewModel userInfo = new UserViewModel
            {
                Id = int.Parse(identity.FindFirst("Id").Value),
                UserName = identity.FindFirst("UserName").Value,
                Roles = roles
            };

            return userInfo;
        } 
    }
}
