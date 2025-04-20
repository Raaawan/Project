using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Models.EmployeeModel;
using Demo.DataAccessLayer.Models.Shared;

namespace Demo.BusinessLogic.DataTransferObjescts
{
    public class EmployeeDto
    {
        public int EmpId { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }

        public decimal Salary { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        //public DateOnly DateOfCreation { get; set; }
        //public string? Address { get; set; }
        //public string? PhoneNumber { get; set; }
        //public DateTime HiringDate { get; set; }
        
    }
}
