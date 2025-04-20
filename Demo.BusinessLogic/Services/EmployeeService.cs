using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services
{
    internal class EmployeeService(IEmployeeRepository _employeeRespoitory) : IEmployeeService
    {

    }
}
