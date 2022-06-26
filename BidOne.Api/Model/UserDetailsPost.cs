using System.ComponentModel.DataAnnotations;

namespace BidOne.Api.Model
{
    public class UserDetailsPost
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
