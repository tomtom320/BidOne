using BidOne.Data.Model;
using System.Threading.Tasks;

namespace BidOne.Data
{
    public interface IDatabase
    {
        Task<UserDetailsData> CreateUser(UserDetailsData userDetailsData);
    }
}
