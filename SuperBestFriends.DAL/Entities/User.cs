using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperBestFriends.Web.DAL.Entities
{
    public sealed class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [StringLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column(TypeName = "ntext")]
        public string Interests { get; set; } = string.Empty;

        public ICollection<User> Friends { get; set; } = [];
        public ICollection<User> FriendsOf { get; set; } = [];

    }
}
