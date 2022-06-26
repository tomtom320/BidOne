using System.ComponentModel.DataAnnotations;

namespace BidOne.Web.Models
{
    public class UserDetailsModel
    {
        public string Id { get; set; } = string.Empty;
            
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
