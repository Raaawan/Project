using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Data.Contexts;

namespace Demo.DataAccessLayer.Repositories
{
    class DepartmentRepository(ApplicationDbContext dbContext)
    {
        #region Dependency inversion
        //ApplicationDbContext dbContext;
        //public DepartmentRepository()
        //{
        //    dbContext = new ApplicationDbContext();
        //}
        #endregion

        #region Dependency injection --> Constructor injection
        private readonly ApplicationDbContext _dbContext = dbContext;

        #endregion
        #region 
        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }
        #endregion
    }
}
