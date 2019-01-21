using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SolidWithBestPrqactices.Data;
using SolidWithBestPrqactices.Services;

namespace SolidWithBestPrqactices
{
	public class Startup
	{
		private IConfiguration _configuration;

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IGreater, Greeter>();
				services.AddDbContext<SolidDbContext>(
					options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
					);
			services.AddScoped<IRestaurantData, SqlRestaurantData>();
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,IGreater greeter,ILogger<Startup> logger)
		{
			//app.UseDefaultFiles();
			//app.UseStaticFiles();
			//app.UseFileServer();//it means both things in one shot
			//app.Use(next => {
			//	return async context =>
			//	{
			//		logger.LogInformation("Request incoming");
			//		if (context.Request.Path.StartsWithSegments("/mym"))
			//		{
			//			await context.Response.WriteAsync("hit the floor");
			//		}
			//		else
			//		{
			//			await next(context);
			//			logger.LogInformation("Request outgoing");
			//		}

			//	};
			//});

			//app.UseWelcomePage(new WelcomePageOptions {
			//	Path = "/getWelcome"
			//});
			//if (env.IsDevelopment())
			//{
			//	app.UseDeveloperExceptionPage();
			//}
			app.UseStaticFiles();
			app.UseMvc(ConfigurationRoutes);
			//app.UseMvc();
			app.Run(async (context) =>
			{
				await context.Response.WriteAsync(greeter.GetGreet());
			});
		}

		private void ConfigurationRoutes(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute("Default",
				"{Controller=Home}/{Action=Index}/{id?}");
		}
	}
}
