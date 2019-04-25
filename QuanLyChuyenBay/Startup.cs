using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using QuanLyChuyenBay.Models;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(QuanLyChuyenBay.Startup))]
namespace QuanLyChuyenBay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        //public void ConfigureServices()
        //{
        //    services.AddDefaultIdentity<IdentityUser>()
        //            .AddDefaultUI(UIFramework.Bootstrap4)
        //            .AddEntityFrameworkStores<ApplicationDbContext>();
        //    services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
        //    {
        //        microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
        //        microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:Password"];
        //    });
        //}
    }
}
