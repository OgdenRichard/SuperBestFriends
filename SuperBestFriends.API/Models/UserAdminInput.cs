using System.ComponentModel.DataAnnotations;

namespace SuperBestFriends.API.Models
{
    public sealed class UserAdminInput
    {
        public long UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Interests { get; set; } = string.Empty;
    }
}
