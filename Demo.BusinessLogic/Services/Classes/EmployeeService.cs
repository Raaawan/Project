using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjescts.DepartmentDtos;
using Demo.BusinessLogic.DataTransferObjescts.EmployeeDtos;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccessLayer.Repositories.Classes;
using Demo.DataAccessLayer.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeService
    {
        #region Get All Employees
        public IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking=false)
        {
            var Employees = _employeeRepository.GetAll(WithTracking);
            //Manual mapping 
            var employeeDtp = Employees.Select(emp => new EmployeeDto()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Email = emp.Email,
                IsActive = emp.IsActive,
                Salary = emp.Salary,
                EmployeeType=emp.EmployeeType.ToString(),
                Gender=emp.Gender.ToString(),
            });
            return employeeDtp;
        }
        #endregion

        #region Get Employee By Id
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                return null;
            }
            else
            {
                return new EmployeeDetailsDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    Address = employee.Address,
                    Age = employee.Age,
                    Email = employee.Email,
                    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                    IsActive = employee.IsActive,
                    PhoneNumber = employee.PhoneNumber,
                    EmployeeType = employee.EmployeeType.ToString(),
                    Gender = employee.Gender.ToString(),
                    CreatedBy = 1,
                    CreatedOn=(DateTime)employee.CreatedOn,
                    LastModifiedBy=1,
                    LastModifiedOn=(DateTime)employee.LastModifiedOn,

                };

            }
        }
        #endregion
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
