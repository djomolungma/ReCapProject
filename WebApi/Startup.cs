using Business.Abstract;
using Business.Concrete;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encription;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
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
            services.AddControllers();            
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();            

            services.AddCors(OptionsBuilderConfigurationExtensions =>
            {
                OptionsBuilderConfigurationExtensions.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://localhost:3000"));
            });

            services.AddCors();//api ye d��ar�dan eri�im sa�lanabilmesi i�in gerekli ; nereden eri�ilebilecegini belirliyoruz Configure i�erisine bak

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            //Microsoft.AspNetCore.Authentication.JwtBearer
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            //ServiceTool.Create(services); //bu sat�r�n yerine alt sat�rda daha fonksiyonel bir geli�tirme yap�ld� 
            services.AddDependencyResolvers(new ICoreModel[] { 
                new CoreModule()
            });

            //Servisler Autofac kullan�larak yeniden implemente edildi
            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<IBrandDal, EfBrandDal>();

            //services.AddSingleton<ICarService, CarManager>();
            //services.AddSingleton<ICarDal, EfCarDal>();

            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<IColorDal, EfColorDal>();

            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();

            //services.AddSingleton<IModelService, ModelManager>();
            //services.AddSingleton<IModelDal, EfModelDal>();

            //services.AddSingleton<IRentalService, RentalManager>();
            //services.AddSingleton<IRentalDal, EfRentalDal>();

            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200", "http://localhost:4201").AllowAnyHeader());//Biz ektedik g�venlik i�in AllowAnyHeader() GET,POST,PUT istekleri //adam� biliyorum ve g�veniyorum
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();//Biz ektedik yetkilenditme i�in
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
