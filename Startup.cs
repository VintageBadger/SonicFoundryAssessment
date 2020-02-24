using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SofoTest.Data;

namespace SofoTest {
    public class Startup {
        public Startup(IConfiguration configuration) {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Use database connection string provided from appsettings.json
            string dbConnectionStringFromAppSettings = Configuration.GetValue<string>("DBConnectionString").ToString();
            services.AddDbContext<SofoDBContext>(options =>
                options.UseSqlite(dbConnectionStringFromAppSettings));
            var optionsBuilder = new DbContextOptionsBuilder<SofoDBContext>();
            optionsBuilder.UseSqlite(dbConnectionStringFromAppSettings);
            SofoDBContext context = new SofoDBContext(optionsBuilder.Options);

            string weatherApiKeyFromAppSettings = Configuration.GetValue<string>("OpenWeatherApiKey");
            // Use dependency injection to create a scoped Location and Weather service
            services.AddScoped<Services.ILocationService, Services.LocationService>(_ => new Services.LocationService(context));
            services.AddScoped<Services.IWeatherService, Services.WeatherService>(_ => new Services.WeatherService(weatherApiKeyFromAppSettings));
           
      


            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
