using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjescts;
using Demo.BusinessLogic.DataTransferObjescts.DepartmentDtos;
using Demo.BusinessLogic.DataTransferObjescts.EmployeeDtos;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        int CreateEmployee(CreatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
        IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking=false);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
    }
}
