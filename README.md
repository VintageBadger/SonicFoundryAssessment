# Net core test

### Notes

- There are example photos of the app in the Instruction folder. It doesn't need to be pretty.
- The project uses an sqlite database called weather.db
- This skeleton code uses Net Core 3.0. You can use version 2.1 if you prefer.
- This project may require Visual Studio 19 to run. You can download Visual Studio Community for free.
- For any style changes use the wwwroot/scss/site.scss file and run Gulp Watch.
- You can ignore any errors from searching for an invalid zipcode
- Use Razor syntax for the form, location list, homepage weather, and location page. Docs: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-3.0

### Steps

1) Configure Startup.cs to use a database connection string and the OpenWeatherMap API key.
2) Implement the LocationService and WeatherService classes according to their respective interfaces. 
	1) The weather service should utilize a GET request to https://openweathermap.org. The API documentation is at https://openweathermap.org/api.
	2) The location service should use Entity Framework to modify the database.
3) Modify Startup.cs to use Dependency Injection for the Location and Weather services. https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0
4) Implement the homepage:
	1) It should have a zipcode search form and list of stored locations in the left column. 
	2) If a user searches for a zipcode:
		1) Fetch the weather for the zipcode
		2) Add the Location to the database
		3) Update the viewmodel to show the weather in the right column.
5) Implement the location page:
	1) After a user chooses a location from the homepage redirect them to /location/{locationId}.
	2) The page should show the current weather. It should also have a delete button to remove the location from the database.
	3) If a user chooses to delete the location remove it from the database and redirect back to the homepage.


### Help

If you have any questions you can email us at bob.obrien@sonicfoundry.com or businesssystems@sonicfoundry.com.