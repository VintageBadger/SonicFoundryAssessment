using Microsoft.AspNetCore.Mvc;
using SofoTest.Data.Models;
using SofoTest.ViewModels;
using SofoTest.Services;
using SofoTest.Services.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SofoTest.Controllers {
    public class HomeController : Controller {

        private ILocationService _locationService { get; set; }
        private IWeatherService _weatherService { get; set; }


        /// <summary>
        /// Instantiates the controller. Inject the Location and Weather services.
        /// </summary>
        /// <param name="locationService"></param>
        /// <param name="weatherService"></param>
        public HomeController(ILocationService locationService, IWeatherService weatherService) {
            _locationService = locationService;
            _weatherService = weatherService;
        }


        [HttpGet]
        public async Task<IActionResult> Index() {
            HomeViewModel model = new HomeViewModel();
            await model.LoadAsync(_locationService);
            return View(model);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]        
        public async Task<IActionResult> Index(HomeViewModel model) {
            Location location = null;
            WeatherModel weather = null;
            if (location == null) {
                //Get the location and save it to the database               
            } else {
                // Just fetch the weather and display it
            }
            await model.LoadAsync(_locationService);
            model.Weather = null; //TODO
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
