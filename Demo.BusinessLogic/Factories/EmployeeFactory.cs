using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjescts.EmployeeDtos;
using Demo.DataAccessLayer.Models.DepartmentModel;
using Demo.DataAccessLayer.Models.EmployeeModel;

namespace Demo.BusinessLogic.Factories
{
    public static class EmployeeFactory
    {
        #region from employee To EmployeeDto
        public static EmployeeDto ToEmployeeDto(this Employees E)
        {
            return new EmployeeDto()
            {
                EmpId = E.Id,
                Name = E.Name,
                Age = E.Age,
                Email = E.Email,
                Gender = E.Gender,
                EmployeeType = E.EmployeeType,
                Salary= E.Salary,
            };
        }

        #endregion

        #region from employee To EmployeeDetailsDto
        public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employees E)
        {
            return new EmployeeDetailsDto()
            {
                EmpId = E.Id,
                Name = E.Name,
                Age = E.Age,
                Email = E.Email,
                Gender = E.Gender,
                EmployeeType = E.EmployeeType,
                Salary = E.Salary,
            };

        }
        #endregion

        #region from EmployeeDTO To Employee
        public static Employees ToEntity(this CreatedEmployeeDto EmployeeDto)
        {
            return new Employees()
            {
                Name = EmployeeDto.Name,
                Age=EmployeeDto.Age,
                Email = EmployeeDto.Email,
                Gender = EmployeeDto.Gender,
                EmployeeType = EmployeeDto.EmployeeType,
                CreatedOn = EmployeeDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        #endregion

        #region from departmentDTO To Department--> update
        public static Employees ToEntity(this UpdatedEmployeeDto employeeDto)
        {
            return new Employees()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Email = employeeDto.Email,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
            };
        }

        #endregion
    }
}
