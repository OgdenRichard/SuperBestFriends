using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperBestFriends.API.Models;
using SuperBestFriends.Business.Abstractions;

namespace SuperBestFriends.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService fileService;
        private readonly IUserService userService;

        public FilesController(IFileService fileService, IUserService userService)
        {
            this.fileService = fileService;
            this.userService = userService;
        }

        // Récupération d'un fichier/image
        [HttpGet("{blobName}")]
        public async Task<string> GetAsync(string blobName)
        {
            byte[] bytes = await this.fileService.GetFromAzureAsync(blobName);

            return Convert.ToBase64String(bytes);
        }

        // Ajout d'un fichier/image
        [HttpPost]
        public async void PostAsync([FromBody] FileInput fileInput)
        {
            byte[] data = Convert.FromBase64String(fileInput.Content);
            await this.fileService.SendToAzureAsync(data, fileInput.Name, fileInput.ContentType);
        }

        // Suppression d'un fichier/image
        [HttpDelete("{id}")]
        public async void DeleteAsync(string id)
        {
            if(id is not null)
            {
                var user = this.userService.GetById(long.Parse(id));

                if(user is not null)
                {
                    await this.fileService.DeleteFromAzureAsync(user.Email);
                }
            }
        }
    }
}
