using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperBestFriends.Business.Abstractions;
using SuperBestFriends.Business.DataTransfertObjects;

namespace SuperBestFriends.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Import du service d'utilisateur
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
    
        // Récupération de tous les utilisateurs
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return this.Ok(this.userService.GetAll());
        }
    }
}
