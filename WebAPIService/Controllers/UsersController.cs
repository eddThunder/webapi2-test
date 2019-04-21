

namespace WebAPIService.Controllers
{
    using BusinessLayer.Dto;
    using BusinessLayer.Interfaces;
    using log4net;
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using WebAPIService.Auth.Helpers;

    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserBusiness _userBusinessService;
        private readonly ILog _logger;

        public UsersController(IUserBusiness userBusinessService, ILog logger)
        {
            _userBusinessService = userBusinessService;
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
                throw;
            }
        }

        [HttpGet]
        [Route("{userId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IHttpActionResult> GetUserById(int userId)
        {
            try
            {
                return Ok(await _userBusinessService.GetByIdAsync(userId));
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
                var encryptedPass = CryptographyHelper.Encrypt(user.Password);
                user.Password = encryptedPass;

               return Ok(await _userBusinessService.Insert(user));
            }
            catch (Exception ex)
            {
                _logger.Error("error in UsersController -> InsertUser: ", ex);
                throw;
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

                throw;
            }
        }
    }
}
