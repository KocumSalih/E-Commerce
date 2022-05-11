using AutoMapper;
using ECommerceProjectWithWebAPI.Business.Abstract;
using ECommerceProjectWithWebAPI.Business.Concrete;
using ECommerceProjectWithWebAPI.Business.Mappings;
using ECommerceProjectWithWebAPI.Core.Extensions;
using ECommerceProjectWithWebAPI.Core.Helpers.JWT;
using ECommerceProjectWithWebAPI.Core.Utilities.Security.Token;
using ECommerceProjectWithWebAPI.Core.Utilities.Security.Token.Jwt;
using ECommerceProjectWithWebAPI.DAL.Abstract;
using ECommerceProjectWithWebAPI.DAL.Concrete.Contexts;
using ECommerceProjectWithWebAPI.DAL.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Swagger => swaggerý servislere ekleme ksýmýný burada yaptýk . Fakat kod kalabalýðýný engelemek adýna Core içerisindeki Extensions klasötrünün altýnda swaggerextensions clasý oluþturuldu ve IServiceCollection burada extend edilerek swagger ayarlarý orada yapýldý. 

            services.AddDbContext<ECommerceProjectWithWebAPIContext>(options => options.UseSqlServer("Server=DESKTOP-DPKMFQT\\S2019; Database=ECommerceProjectWithWebAPI; uid=sa; pwd=1;"));

            services.AddControllers();
            services.AddCustomSwagger();
            services.AddCustomJwtTokken(Configuration);

            #region AutoMapper

            var mapperConfig = new MapperConfiguration(mc =>
              {
                  mc.AddProfile(new MappingProfile());
              });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region DI
            services.AddTransient<IUserDal, EfUserDal>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, JwtTokenService>();
            services.AddTransient<IAuthService, AuthService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
                
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
