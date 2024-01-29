using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NVSSoft.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService usersService;

        public UsersController(IConfiguration configuration)
        {
            this.usersService = new UsersService(configuration);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = usersService.GetUsers();
            return Ok(users);
        }
    }

}
