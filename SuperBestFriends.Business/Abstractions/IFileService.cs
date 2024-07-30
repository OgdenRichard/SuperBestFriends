namespace SuperBestFriends.Business.Abstractions
{
    public interface IFileService
    {
        Task<byte[]> GetFromAzureAsync(string filename);

        Task SendToAzureAsync(byte[] data, string fileName, string contentType);

        Task DeleteFromAzureAsync(string fileName);
    }
}
