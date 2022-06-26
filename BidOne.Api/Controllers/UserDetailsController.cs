using AutoMapper;
using BidOne.Api.Model;
using BidOne.Service;
using BidOne.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BidOne.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsService _userDetailsService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserDetailsController> _logger;

        public UserDetailsController(ILogger<UserDetailsController> logger, IUserDetailsService userDetailsService, IMapper mapper)
        {
            _logger = logger;
            _userDetailsService = userDetailsService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("{sGuid}")]
        public ActionResult Get(string sGuid)
        {
            // Need to inplement
            return BadRequest();
        }


        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] UserDetailsPost usrDetailsModel)
        {
            if (ModelState.IsValid)
            {
                var usrDetails = _mapper.Map<UserDetails>(usrDetailsModel);
                
                var retUser = await _userDetailsService.CreateUser(usrDetails);
                var Uri = new Uri($"{Request.Path}/{retUser.Id.ToString()}", UriKind.Relative);
                return Created(Uri.ToString(), retUser.Id);
            }

            return BadRequest();
        }


    }

}
