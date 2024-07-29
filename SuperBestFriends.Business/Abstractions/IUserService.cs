using SuperBestFriends.Business.DataTransfertObjects;

namespace SuperBestFriends.Business.Abstractions
{
    public interface IUserService
    {
        List<UserDto> GetAll();

        Task<UserDto> AddFriendAsync(long id);
    }
}
