using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(DepartmentServce departmentServce) : Controller
    {
        public IActionResult Index()
        {
            var Departments = departmentServce.GetAllDepartments();

            return View();
        }
    }
}
