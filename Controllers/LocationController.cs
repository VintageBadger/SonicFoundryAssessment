using Microsoft.AspNetCore.Mvc;
using SofoTest.Data;
using SofoTest.Data.Models;
using SofoTest.Services;
using SofoTest.Services.Models;
using System;
using System.Threading.Tasks;

namespace SofoTest.Controllers {
    public class LocationController : Controller {

        private SofoDBContext _context { get; set; }
        private ILocationService _locationService { get; set; }
        private IWeatherService _weatherService {get;set;}

        public LocationController(SofoDBContext context, ILocationService locationService, IWeatherService weatherService) {
            _context = context;
            _locationService = locationService;
            _weatherService = weatherService;
        }


        [HttpGet]
        [Route("/Location/{locationId}")]
        public async Task<IActionResult> Index(Guid locationId) {
            return Ok(new NotImplementedException());
        }

        [HttpPost]
        [Route("/Location/{locationId}")]
        public async Task<IActionResult> Delete(Guid locationId) {
            return Ok(new NotImplementedException());
        }



    }
}
