using SuperBestFriends.Business.DataTransfertObjects;

namespace SuperBestFriends.Business.Abstractions
{
    public interface IUserService
    {
        List<UserDto> GetAll();

        UserProfileDto? GetById(long id);

        Task<long> UpdateAsync(long userId, UserUpdateDto user);

        Task<bool> AddFriendAsync(long userId, long friendId);

        Task<bool> RemoveFriendAsync(long userId, long friendId);
    }
}
