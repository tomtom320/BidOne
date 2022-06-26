using AutoMapper;
using BidOne.Api.Model;
using BidOne.Service.Model;

namespace BidOne.Api
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<UserDetailsPost, UserDetails>();
        }
    }
}
