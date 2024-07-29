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


        [HttpGet]
        public ActionResult<IEnumerable<UserAdminDto>> GetAll()
        {
            return this.Ok(this.adminService.GetAll());
        }
    }
}
