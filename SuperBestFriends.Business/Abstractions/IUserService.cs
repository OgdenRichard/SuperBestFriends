using SuperBestFriends.Business.DataTransfertObjects;

namespace SuperBestFriends.Business.Abstractions
{
    public interface IUserService
    {
        List<UserDto> GetAll();

        UserAdminDto? GetById(long id);

        Task<bool> AddFriendAsync(long userId, long friendId);

        Task<bool> RemoveFriendAsync(long userId, long friendId);
    }
}
