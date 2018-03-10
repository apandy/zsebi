using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Zsebi2.DataLayer;
using Zsebi2.Models;
using Zsebi2.Services;

namespace Zsebi2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private MapperConfiguration _mapperConfig;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SiteContext>(options =>
                Microsoft.EntityFrameworkCore.MySqlDbContextOptionsExtensions.UseMySql(
                    options,
                    Configuration.GetSection("Database").GetValue<string>("ConnectionString")
                //@"Server=localhost;database=zsebi;uid=root;pwd=admin;"
                )
            );

            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = new PathString("/Admin/Login");
                    config.LogoutPath = new PathString("/Admin/Logout");
                });

            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleModel>()
                    .ForMember(e => e.GenerateUrl, c => c.Ignore())
                    .ReverseMap();
            });
            _mapperConfig.AssertConfigurationIsValid();
            services.AddSingleton(_mapperConfig.CreateMapper());

            services.AddScoped(typeof(IUserServices), typeof(UserServices));
            services.AddScoped(typeof(ITeamService), typeof(TeamService));
            services.AddScoped(typeof(IArticleService), typeof(ArticleService));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
