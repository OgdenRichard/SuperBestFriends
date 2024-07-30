using SuperBestFriends.Business.DataTransfertObjects;

namespace SuperBestFriends.Business.Abstractions
{
    public interface IAdminService
    {
        List<UserAdminDto> GetAll();

        UserAdminDto? GetById(long id);

        Task<long> CreateAsync(UserAdminDto user);

        Task<long> UpdateAsync(UserAdminDto user);

        Task<bool> DeleteAsync(long id);
    }
}
