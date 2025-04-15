using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Data.Contexts;

namespace Demo.DataAccessLayer.Repositories
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository
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

        #region get by id
        public Department? GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }
        #endregion

        #region Get all Depts
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _dbContext.Departments.ToList();
            }
            else
            {
                return _dbContext.Departments.AsNoTracking().ToList();
            }

        }

        #endregion

        #region Update Dept
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Delete Dept
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Add Dept  
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }
        #endregion
    }
}
