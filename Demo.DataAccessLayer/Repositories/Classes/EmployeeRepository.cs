using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Data.Contexts;
using Demo.DataAccessLayer.Repositories.Interfaces;

namespace Demo.DataAccessLayer.Repositories.Classes
{
    public class EmployeeRepository(ApplicationDbContext dbContext) : GenericRepository<Employees>(dbContext), IEmployeeRepository
    {
        #region Dependency injection --> Constructor injection
        private readonly ApplicationDbContext _dbContext = dbContext;

        #endregion
    }
}
