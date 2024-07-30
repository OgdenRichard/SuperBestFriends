namespace SuperBestFriends.Business.DataTransfertObjects
{
    public sealed class UserProfileDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Interests { get; set; } = string.Empty;
        public List<UserDto> Friends { get; set; } = [];
    }
}
