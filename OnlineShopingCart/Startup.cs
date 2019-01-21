using CustomerManagementSystem.Data;

using CustomerManagementSystem.Models;
using CustomerManagementSystem.Repositories;
using CustomerManagementSystem.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;	
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagementSystem
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<OnlineDbContext>(
				options => options.UseSqlServer(_configuration.GetConnectionString("OnlineShopingCart"))
				);
			services.AddTransient<IRepositories<Customer>, Repositories<Customer>>();
			services.AddTransient<IProxyService<Customer>, ProxyService>();
			services.AddMvc();

		}
	
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//app.UseMvcWithDefaultRoute();
			app.UseMvc(RouteConfigurations);
			app.UseNodeModules(env.ContentRootPath);
			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}

		private void RouteConfigurations(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute("Default",
				"{Controller=Home}/{Action=Index}/{id?}");
		}
	}
}
