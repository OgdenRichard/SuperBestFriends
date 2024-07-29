using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperBestFriends.API.Models;
using SuperBestFriends.Business.Abstractions;
using SuperBestFriends.Business.DataTransfertObjects;

namespace SuperBestFriends.API.Controllers
{
    [Route("api/[controller]/users")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        // Import du service Admin
        private readonly IAdminService adminService;
        public AdminsController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        // Récupération de tous les utilisateurs
        [HttpGet]
        public ActionResult<IEnumerable<UserAdminDto>> GetAll()
        {
            return this.Ok(this.adminService.GetAll());
        }

        // Récupération d'un utilisateur via son ID
        [HttpGet("{id:long}")]
        public ActionResult<UserAdminDto> GetById(long id)
        {
            var userFound = this.adminService.GetById(id);

            return userFound is null
                ? NotFound()
                : Ok(userFound);
        }

        // Création d'un utilisateur
        [HttpPost]
        public async Task<ActionResult<long>> CreateAsync([FromBody] UserAdminInput user)
        {
            var createdId = await this.adminService.CreateAsync(new UserAdminDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                Interests = user.Interests
            });

            return createdId > 0
                ? Created($"/api/admins/users/{createdId}", null)
                : Problem();
        }
    }
}
