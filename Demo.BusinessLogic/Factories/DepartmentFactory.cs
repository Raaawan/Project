using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjescts;
using Demo.DataAccessLayer.Models;

namespace Demo.BusinessLogic.Factories
{
    static class DepartmentFactory
    {
        #region from department To DepartmentDto
        public static DepartmentDto ToDepartmentDto( this Department D)
        {
            return new DepartmentDto()
            {
                DeptId = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime((DateTime)D.CreatedOn)
            };
        }

        #endregion

        #region from department To DepartmentDetailsDto
        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department D)
        {
            return new DepartmentDetailsDto()
            {
                Id = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                CreatedOn = DateOnly.FromDateTime((DateTime)D.CreatedOn),
                CreatedBy = D.CreatedBy,
                LastModifiedBy = D.LastModifiedBy,
                IsDeleted = D.IsDeleted,
            };

        }
        #endregion

        #region from departmentDTO To Department
        public static Department ToEntity(this CreatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn=departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        #endregion

        #region from departmentDTO To Department--> update
        public static Department ToEntity(this UpdatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id= departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        #endregion
    }
}
