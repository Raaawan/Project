using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjescts;

namespace Demo.BusinessLogic.Services
{
    public class IEmployeeService
    {
        int AddEmployee(CreatedDepartmentDto employeeDto);
        bool DeleteEmployee(int id);
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDetailsDto? GetEmployeeById(int id);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
    }
}
