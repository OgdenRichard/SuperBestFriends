using SuperBestFriends.Business.DataTransfertObjects;
using SuperBestFriends.Web.Models.User;
using System.ComponentModel.DataAnnotations;

namespace SuperBestFriends.Web.Models.Profile
{
    public class ProfileViewModel
    {
        public long UserId { get; set; }

        [Display(Name = "Prénom")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Nom")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Date de naissance")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Age")]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;

                if (BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }

        public bool IsFriend { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Centres d'intérêt")]
        public string Interests { get; set; } = string.Empty;

        [Display(Name = "Photo de profil")]
        public IFormFile? Image { get; set; }

        [Display(Name = "Liste d'utilisateurs'")]
        public List<ProfileViewModel> People { get; set; } = [];

        public List<UserDto> Friends { get; set; } = [];

        public static ProfileViewModel FromDto(UserProfileDto user)
        {
            return new ProfileViewModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Interests = user.Interests,
                Friends = user.Friends.ToList()
            };
        }

        public static ProfileViewModel FriendFromDto(UserDto user)
        {
            return new ProfileViewModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
