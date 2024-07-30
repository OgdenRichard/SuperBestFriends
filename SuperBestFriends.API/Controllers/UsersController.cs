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

        // Récupération d'un utilisateur via son ID
        [HttpGet("{id:long}")]
        public ActionResult<UserAdminDto> GetById(long id)
        {
            var userFound = this.userService.GetById(id);

            return userFound is null
                ? NotFound()
                : Ok(userFound);
        }

        // Ajout d'un ami
        [HttpPost]
        public async Task<ActionResult> AddFriendAsync(long userId, long friendId)
        {
            var isSuccess = await this.userService.AddFriendAsync(userId, friendId);
            if (!isSuccess)
                return BadRequest("Unable to add your new friend.");

            return Ok("You've got a new friend !");
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveFriendAsync(long userId, long friendId)
        {
            var isSuccess = await this.userService.RemoveFriendAsync(userId, friendId);
            if (!isSuccess)
                return BadRequest("Unable to remove your friend");

            return Ok("At least say farewell to your old friend");
        }
    }
}
