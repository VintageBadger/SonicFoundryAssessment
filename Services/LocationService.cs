using Microsoft.EntityFrameworkCore;
using SofoTest.Data;
using SofoTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SofoTest.Services {

    public interface ILocationService {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<Location> GetLocation(Guid id);
        Task<Location> GetLocationByZipCode(string zipCode);
        Task<Location> AddLocation(string title, string lat, string lng);
        Task<Location> RemoveLocation(Guid id);
    }



    /// <summary>
    /// Use this class to handle all the logic for fetching/adding/removing
    /// locations from the database.
    /// </summary>
    public class LocationService : ILocationService {

        private SofoDBContext _context { get; set; }

        public LocationService(SofoDBContext context) {
            _context = context;
        }


        /// <summary>
        /// Fetch all the locations stored in the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Location>> GetAllLocations() {
            return null;
        }

        /// <summary>
        /// Fetch a location by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Location> GetLocation(Guid id) {
            return null;
        }

        /// <summary>
        /// Fetch a location from the database by zipcode
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public async Task<Location> GetLocationByZipCode(string zipCode) {
            return null;
        }

        /// <summary>
        /// Create and add a new location to the database
        /// </summary>
        /// <param name="title">Name of the location. Ex) Madison, Chicago</param>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        public async Task<Location> AddLocation(string title, string lat, string lng) {
            return null;
        }

        /// <summary>
        /// Delete a location from the database
        /// </summary>
        /// <param name="id">Id of the location entity</param>
        /// <returns></returns>
        public async Task<Location> RemoveLocation(Guid id) {
            return null;
        }
    }
}
