using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjescts.DepartmentDtos;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccessLayer.Models;
using Demo.DataAccessLayer.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentServce(IDepartmentRepository _departmentRepository) : IDepartmentServce
    {

        #region Get all departments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return departments.Select(D => D.ToDepartmentDto());
        }
        #endregion

        #region Get Department By Id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var derpartment = _departmentRepository.GetById(id);
            //if(derpartments is null)
            //{
            //    return null;
            //}
            //else
            //{
            //    //var departmentToReturn= new DepartmentDetailsDto(derpartments)
            //    return derpartments.ToDepartmentDetailsDto();
            //}
            return derpartment is null ? null : derpartment.ToDepartmentDetailsDto();
        }
        #endregion

        #region Add new department
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmentRepository.Add(department);
        }
        #endregion

        #region Update department
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {

            return _departmentRepository.Update(departmentDto.ToEntity());
        }
        #endregion

        #region Delete department
        public bool DeleteDepartment(int id)
        {
            var Dept = _departmentRepository.GetById(id);
            if (Dept is null) return false;
            else
            {
                int Result = _departmentRepository.Remove(Dept);
                if (Result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
