using BusinessLayer.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIService.Controllers
{
    [RoutePrefix("api/roles")]
    public class RoleController : ApiController
    {
        private readonly IRoleBusiness _roleBusinessService;
        public RoleController(IRoleBusiness roleBusinessService)
        {
            _roleBusinessService = roleBusinessService;
        }

        [Route("all")]
        public async Task<IHttpActionResult> GetAllRoles()
        {
            try
            {
                return Ok(await _roleBusinessService.GetAllRoles());
            }
            catch (Exception ex)
            {
                //_logger.LogError("error in UsersController -> GetAllUsersAsync: ", ex);
                throw;
            }
        }
    }
}
