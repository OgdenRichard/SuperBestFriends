using System.ComponentModel.DataAnnotations;

namespace SuperBestFriends.Web.Models.User
{
    public class UserBaseViewModel
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

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Centres d'intérêt")]
        public string Interests { get; set; } = string.Empty;

        [Display(Name = "Liste des amis")]
        public List<UserInputViewModel> Friends { get; set; } = [];

        [Display(Name = "Photo de profil")]
        public IFormFile? Image { get; set; }
    }
}
