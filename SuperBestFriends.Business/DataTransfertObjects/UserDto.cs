namespace SuperBestFriends.Business.DataTransfertObjects
{
    public sealed class UserDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

    }
}
