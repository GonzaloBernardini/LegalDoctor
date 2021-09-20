using System;
using AppMvcLoginReg.Areas.Identity.Data;
using AppMvcLoginReg.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AppMvcLoginReg.Areas.Identity.IdentityHostingStartup))]
namespace AppMvcLoginReg.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppMvcLoginRegDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AppMvcLoginRegDbContextConnection")));
                //Conexion con los usuarios! no borrar
                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                   //opciones para identificacion de usuarios
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })


                    .AddEntityFrameworkStores<AppMvcLoginRegDbContext>();
            });
        }
    }
}