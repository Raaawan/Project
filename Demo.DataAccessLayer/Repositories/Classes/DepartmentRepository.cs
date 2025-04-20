using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Data.Contexts;
using Demo.DataAccessLayer.Models.DepartmentModel;
using Demo.DataAccessLayer.Repositories.Interfaces;

namespace Demo.DataAccessLayer.Repositories.Classes
{
    public class DepartmentRepository(ApplicationDbContext dbContext) :GenericRepository<Department>(dbContext) ,IDepartmentRepository
    {
        #region Dependency injection --> Constructor injection
        private readonly ApplicationDbContext _dbContext = dbContext;

        #endregion
    }
}
