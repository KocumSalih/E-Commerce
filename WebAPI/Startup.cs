using AutoMapper;
using ECommerceProjectWithWebAPI.Business.Abstract;
using ECommerceProjectWithWebAPI.Business.Concrete;
using ECommerceProjectWithWebAPI.Business.Mappings;
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
            services.AddDbContext<ECommerceProjectWithWebAPIContext>(options => options.UseSqlServer("Server=DESKTOP-DPKMFQT\\S2019; Database=ECommerceProjectWithWebAPI; uid=sa; pwd=1;"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Bearer þemasýný kullanan JWT yetkilendirme baþlýðý \r\n\r\n 'Bearer' [Boþluk] giriniz."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            #region JWT

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecurityKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

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
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
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
