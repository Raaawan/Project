using Demo.DataAccessLayer.Data.Contexts;
using Demo.DataAccessLayer.Repositories;
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
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection"));

            });
            #endregion
            var app = builder.Build();

              

            app.Run();
        }
    }
}
