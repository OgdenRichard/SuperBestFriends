using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SuperBestFriends.Web.Models.Users
{
    public class UserInputViewModel
    {
        public long UserId { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Veuillez renseigner le Prénom")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Veuillez renseigner le Nom")]
        public string LastName { get; set; } = string.Empty;
        
        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "Veuillez renseigner la date de Naissance")]
        public DateTime BirthDate { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Veuillez renseigner l'émail")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Centres d'intérêt")]
        public string Interests { get; set; } = string.Empty;

        [Display(Name = "Amis")]
        public List<SelectListItem> Friends { get; set; } = new();

        [Display(Name = "Liste des amis")]
        public List<int> FriendIds { get; set; } = new();

        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Display(Name = "Photo de profil")]
        public IFormFile? Image { get; set; }

    }
}
