using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using SuperBestFriends.Business.Abstractions;

namespace SuperBestFriends.Business.Services
{
    internal sealed class FileService : IFileService
    {
        private readonly string storageConnectionString;
        private readonly string storageContainerName;

        public FileService(IConfiguration configuration)
        {
            storageConnectionString = configuration["Storage:ConnectionString"];
            storageContainerName = configuration["Storage:Container"];
        }

        public async Task<byte[]> GetFromAzureAsync(string filename)
        {
            BlobContainerClient blobContainer = new(storageConnectionString, storageContainerName);
            await blobContainer.CreateIfNotExistsAsync();

            BlobClient blobClient = blobContainer.GetBlobClient(filename);

            if(await blobClient.ExistsAsync())
            {
                using var ms = new MemoryStream();
                await blobClient.DownloadToAsync(ms);

                return ms.ToArray();
            }

            return Array.Empty<byte>();
        }

        public async Task SendToAzureAsync(byte[] data, string fileName, string contentType)
        {
            BlobContainerClient blobContainer = new(storageConnectionString, storageContainerName);
            await blobContainer.CreateIfNotExistsAsync();

            BlobClient blobClient = blobContainer.GetBlobClient(fileName);

            using (var ms = new MemoryStream(data, false))
            {
                var blobHeaders = new BlobHttpHeaders
                {
                    ContentType = contentType
                };

                await blobClient.UploadAsync(ms, new BlobUploadOptions { HttpHeaders = blobHeaders });
            }
        }

        public async Task DeleteFromAzureAsync(string fileName)
        {
            BlobContainerClient blobContainerClient = new(storageConnectionString, storageContainerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }
    }
}
