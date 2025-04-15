using System.Reflection;

namespace Demo.DataAccessLayer.Data.Contexts
{
    internal class ApplicationDbContext:DbContext
    {
        #region Properties
        protected DbSet<Department> Departments { get; set; }
        #endregion

        #region onConfigure Method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("ConnectionString");
        }

        #endregion

        #region OnCreating Method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); 
        }
        #endregion
    }
}
