using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperBestFriends.Business.Abstractions;
using SuperBestFriends.Business.DataTransfertObjects;

namespace SuperBestFriends.API.Controllers
{
    [Route("api/[controller]")]
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
    }
}
