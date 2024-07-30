using SuperBestFriends.Business.DataTransfertObjects;

namespace SuperBestFriends.Business.Abstractions
{
    public interface IUserService
    {
        List<UserDto> GetAll();

        Task<bool> AddFriendAsync(long userId, long friendId);
    }
}
