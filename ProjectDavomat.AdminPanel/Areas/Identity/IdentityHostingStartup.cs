using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectDavomat.AdminPanel.Data;

[assembly: HostingStartup(typeof(ProjectDavomat.AdminPanel.Areas.Identity.IdentityHostingStartup))]
namespace ProjectDavomat.AdminPanel.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProjectDavomatAdminPanelContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("PostgreDb")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ProjectDavomatAdminPanelContext>();
            });
        }
    }
}