using System.ComponentModel.DataAnnotations;
using System.Linq;
using SuperBestFriends.Web.DAL.Entities;


using SuperBestFriends.Web.Models.Users;

namespace SuperBestFriends.Web.Models.Users
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

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Centres d'intérêt")]
        public string Interests { get; set; } = string.Empty;

        [Display(Name = "Liste des amis")]
        public string Friends { get; set; } = string.Empty;

        [Display(Name = "Photo de profil")]
        public IFormFile? Image { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }


        public static UserBaseViewModel FromModel(User user)
        {
            return new UserBaseViewModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email= user.Email,
                BirthDate = user.BirthDate,
                Address=user.Address,
                //Friends = string.Join(",", user.Friends.Select(f => f.LastName))
            };

        }
    }
}


