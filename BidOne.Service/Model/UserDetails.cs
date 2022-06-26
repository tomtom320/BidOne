using System.ComponentModel.DataAnnotations;

namespace BidOne.Service.Model
{
    public class UserDetails
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
