using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectDavomat.AdminPanel.Services;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.BL.Repasitory;
using ProjectDavomat.Data.DataLayer;

namespace ProjectDavomat.AdminPanel
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
            services.AddScoped<ILeaderInterface, LeaderRepository>();
            services.AddScoped<ITeacherInterface, TeacherRepasitory>();

            services.AddScoped<IUserInterface, UserRepasitory>();

            services.AddScoped<IStaffInterface, StaffRepasitory>();
            services.AddTransient<IStatInterface, StatRepo>();

            services.AddScoped<ICourseInterface, CourseRepasitory>();

            services.AddScoped<ICourseCategoryInterface, CourseCategoryRepasitory>();

            services.AddScoped<IServiceInterface, ServiceRepasitory>();

            services.AddScoped<IDeleteSaveimageInterface, DeleteSaveimageRepasitory>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("LocalPostgreDb")));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
