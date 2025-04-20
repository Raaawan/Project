using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Models.EmployeeModel;
using Demo.DataAccessLayer.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services
{
    internal class EmployeeService(IEmployeeRepository _employeeRespoitory) : IEmployeeRepository
    {
        public int Add(Employees entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employees> GetAll(bool WithTracking = false)
        {
            throw new NotImplementedException();
        }

        public Employees? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Remove(Employees entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Employees entity)
        {
            throw new NotImplementedException();
        }
    }
}
