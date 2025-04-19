using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentServce _departmentServce) : Controller
    {
        public IActionResult Index()
        {
            var Departments = _departmentServce.GetAllDepartments();

            return View(Departments);
        }
    }
}
