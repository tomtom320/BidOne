using BidOne.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BidOne.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;


        public string createdNewUserGuid = String.Empty;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View(new UserDetailsModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Index(UserDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                string userDeatialsModel = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(userDeatialsModel, Encoding.UTF8, "application/json");
                string apiEndPoint = _config["apiEndPoint"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiEndPoint);

                    var result = await client.PostAsync("/UserDetails", content);

                    model.Id =  await result.Content.ReadAsStringAsync();
                     

                    if (result.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("User details added.");
                        return View(model);
                    }
                }
            }
            return Error();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
