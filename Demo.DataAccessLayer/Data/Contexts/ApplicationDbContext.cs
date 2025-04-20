using System.Reflection;
using Demo.DataAccessLayer.Models.DepartmentModel;

namespace Demo.DataAccessLayer.Data.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {


        #region Properties
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
        #endregion 

        #region OnCreating Method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
        #endregion


    }
}
