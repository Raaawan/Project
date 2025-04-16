using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Models;

namespace Demo.BusinessLogic.DataTransferObjescts
{
    public class DepartmentDetailsDto
    {
        //public DepartmentDetailsDto(Department departments)
        //{
        //    Id = derpartments.Id,
        //    Name = derpartments.Name,
        //    Code = derpartments.Code,
        //    Description = derpartments.Description,
        //    CreatedOn = DateOnly.FromDateTime(derpartments.CreatedOn),
        //    CreatedBy = derpartments.CreatedBy,
        //    LastModifiedBy = derpartments.LastModifiedBy,
        //    IsDeleted = derpartments.IsDeleted,
        //}
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateOnly LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
