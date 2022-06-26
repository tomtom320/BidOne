using System;

namespace BidOne.Api.Model
{
    public class UserDetailsDTO
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
