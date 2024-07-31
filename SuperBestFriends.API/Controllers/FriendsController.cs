using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperBestFriends.Business.Abstractions;
using SuperBestFriends.Business.DataTransfertObjects;

namespace SuperBestFriends.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        // Import du service d'utilisateur
        private readonly IUserService userService;
        public FriendsController(IUserService userService)
        {
            this.userService = userService;
        }

        // Récupération de la liste 
        [HttpGet("{id:long}")]
        public ActionResult<List<UserDto>> GetNonFriends(long id)
        {
            var userFound = this.userService.GetNonFriends(id);

            return userFound is null
                ? NotFound()
                : Ok(userFound);
        }
    }
}
