using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Models.EmployeeModel;
using Demo.DataAccessLayer.Models.Shared;

namespace Demo.BusinessLogic.DataTransferObjescts
{
    public class UpdatedEmployeeDto
    {
        [Required(ErrorMessage = "Name is Required!!!")]
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly LastModifiedBy { get; set; }
    }
}
