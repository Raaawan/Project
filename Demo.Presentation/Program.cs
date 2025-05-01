using Demo.BusinessLogic.Profiles;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccessLayer.Data.Contexts;
using Demo.DataAccessLayer.Repositories.Classes;
using Demo.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddDbContext<ApplicationDbContext>(options => {
                //options.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]);
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentServce, DepartmentServce>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            #endregion
            var app = builder.Build();
            #region Configure HTTP request pipeLine 
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            #endregion


            app.Run();
        }
    }
}
