using Core.Mappers;
using Core.Models;
using Core.Players;
using Core.SourceLists;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace omxplayer_remote_aspnetcore
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddOptions();
      // Add framework services.
      services.AddMvc();

      services.Configure<FileSourceOptions>(Configuration.GetSection("FileSource"));
      services.Configure<OmxPlayerOptions>(Configuration.GetSection("OmxPlayer"));

      services.AddTransient<SourceFactory>();
      services.AddTransient<ISourceList, FileSourceList>();
      services.AddSingleton<OmxPlayer>();
      services.AddSingleton<LivestreamerPlayer>();
    }



    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        var options = new WebpackDevMiddlewareOptions() { HotModuleReplacement = true };
        app.UseWebpackDevMiddleware(options);
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "api/{controller=Home}/{action=Index}/{id?}");
        routes.MapSpaFallbackRoute(
          name: "spa-fallback",
          defaults: new { controller = "Home", action = "Index" });
      });
    }
  }
}
