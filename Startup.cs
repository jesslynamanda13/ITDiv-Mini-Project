using ITDiv_MiniProject.Helper;
using ITDiv_MiniProject.Model;
using ITDiv_MiniProject.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace ITDiv_MiniProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins("http://127.0.0.1:5500")  
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .AllowAnyHeader());
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            app.UseCors("AllowSpecificOrigin");
          

        }
    }
}
