using System;
using System.ComponentModel.DataAnnotations;

namespace BidOne.Data.Model
{
    public class UserDetailsData
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
