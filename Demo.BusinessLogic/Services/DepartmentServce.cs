using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer.Models;
using Demo.DataAccessLayer.Repositories;

namespace Demo.BusinessLogic.Services
{
    internal class DepartmentServce
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentServce(IDepartmentRepository departmentRepository) { }

        #region Get by id Service
        public int Test() {
            List<Department> Departments = _departmentRepository.GetAll().ToList();
            return Departments.Count;
        }
        #endregion
    }
}
