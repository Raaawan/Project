using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjescts;
using Demo.BusinessLogic.Factories;
using Demo.DataAccessLayer.Repositories.Classes;
using Demo.DataAccessLayer.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services
{
    internal class EmployeeService(IEmployeeRepository _employeeRespoitory) : IEmployeeService
    {
        #region Get all Employees
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var employees = _employeeRespoitory.GetAll();
            return (IEnumerable<DepartmentDto>)employees.Select(D => D.ToEmployeeDto());
        }
        #endregion

        #region Get Employee By Id
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRespoitory.GetById(id);
            return employee is null ? null : employee.ToEmployeeDetailsDto();
        }
        #endregion

        
    }
}
