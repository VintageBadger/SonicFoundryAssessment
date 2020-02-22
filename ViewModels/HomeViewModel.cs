using SofoTest.Data.Models;
using SofoTest.Services;
using SofoTest.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SofoTest.ViewModels {
    public class HomeViewModel {
        public WeatherModel Weather;
        public IEnumerable<Location> Locations { get; set; }
        public string SearchQuery { get; set; }

        public async Task LoadAsync(ILocationService service) {
            Locations = await service.GetAllLocations();
        }
    }
}
