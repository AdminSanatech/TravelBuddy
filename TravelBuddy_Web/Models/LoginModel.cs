using System.ComponentModel.DataAnnotations;
namespace TravelBuddy_Web.Models
{

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
       
    }

}


