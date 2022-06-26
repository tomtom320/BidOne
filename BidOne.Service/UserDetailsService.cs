using BidOne.Data;
using BidOne.Data.Model;
using BidOne.Service.Model;
using System.Threading.Tasks;

namespace BidOne.Service
{

    public interface IUserDetailsService
    {
        Task<UserDetailsData> CreateUser(UserDetails userDetails);
    }


    public class UserDetailsService : IUserDetailsService
    {
        private readonly IDatabase _database;

        public UserDetailsService(IDatabase database)
        {
            _database = database;
        }

        public async Task<UserDetailsData> CreateUser(UserDetails userDetails)
        {

            UserDetailsData userDetailsData = new UserDetailsData
            {
                FirstName = userDetails.FirstName,
                LastName = userDetails.LastName
            };

            return await _database.CreateUser(userDetailsData);
        }
    }
}
