using CItyInfo.API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace CItyInfo.API
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
				services.AddMvc()
				.AddJsonOptions(o =>
					{
						switch (o.SerializerSettings.ContractResolver)
						{
							case null:
								return;
							case DefaultContractResolver castedResolver:
								castedResolver.NamingStrategy = null;
								break;
						}
					});

			services.AddTransient<ICitiesService, CitiesService>();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "My API",
					Description = "My First ASP.NET Core Web API",
					TermsOfService = "None",
					Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();
			loggerFactory.AddDebug();
			//loggerFactory.AddProvider(new NLogLoggerProvider());
			loggerFactory.AddNLog();
			app.UseMvc();

			app.UseSwagger();
						app.UseSwaggerUI(c =>

			{

				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

			});

			app.UseStatusCodePages();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}
	}
}
