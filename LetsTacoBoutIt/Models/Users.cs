using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LetsTacoBoutIt.Models
{
    public class Users
    {
        public int id { get; set; }


        [Required]
        [StringLength(255, MinimumLength = 2)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;


        [Required]
        [StringLength(255, MinimumLength = 2)]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public string FirebaseId { get; set; }

        public string LoginType { get; set; }

    }
}
