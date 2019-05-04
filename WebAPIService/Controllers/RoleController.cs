

namespace WebAPIService.Controllers
{
    using BusinessLayer.Interfaces;
    using log4net;
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    [Authorize]
    [RoutePrefix("api/roles")]
    public class RoleController : ApiController
    {
        private readonly IRoleBusiness _roleBusinessService;
        private readonly ILog _logger;

        public RoleController(IRoleBusiness roleBusinessService, ILog logger)
        {
            _roleBusinessService = roleBusinessService;
            _logger = logger;
        }

        [Route("all")]
        public async Task<IHttpActionResult> GetAllRoles()
        {
            try
            {
                var result = await _roleBusinessService.GetAllRoles();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error("error in UsersController -> GetUserById: ", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
