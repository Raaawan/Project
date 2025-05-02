using Demo.BusinessLogic.DataTransferObjescts.DepartmentDtos;
using Demo.BusinessLogic.DataTransferObjescts.EmployeeDtos;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccessLayer.Models.EmployeeModel;
using Demo.DataAccessLayer.Models.Shared;
using Demo.Presentation.ViewModels.DepartmentViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService,ILogger<EmployeeController> _logger, IWebHostEnvironment _environment) : Controller
    {
        #region Index Action
        public IActionResult Index()
        {
            var employee = _employeeService.GetAllEmployees();
            return View(employee);
        }
        #endregion

        #region Create Employee
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = _employeeService.CreateEmployee(employeeDto);
                    if (Result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "can not be empty");
                        return View(employeeDto);
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(String.Empty, "can not be empty");
                        return View(employeeDto);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View(employeeDto);
                    }
                }
            }
            else
            {
                return View(employeeDto);
            }
        }
        #endregion

        #region Employee Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            else
            {
                var employee = _employeeService.GetEmployeeById(id.Value);
                return employee is null ? NotFound() : View(employee);
            }
        }
        #endregion

        #region Edit employee
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound();
            var employeeDto = new UpdatedEmployeeDto()
            {
                Id=employee.Id,
                Name=employee.Name,
                Salary=employee.Salary,
                Address=employee.Address,
                Age=employee.Age,
                Email=employee.Email,
                PhoneNumber=employee.PhoneNumber,
                IsActive=employee.IsActive,
                HiringDate=employee.HiringDate,
                Gender=Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType)
            };
            return View(employeeDto);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, UpdatedEmployeeDto employeeDto)
        {
            if (!id.HasValue || id != employeeDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(employeeDto);
            try
            {
                var Result = _employeeService.UpdateEmployee(employeeDto);
                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {

                    ModelState.AddModelError(string.Empty, "Employee can not be updated");
                    return View(employeeDto);
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                    return View(employeeDto);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }


            }
        }

        #endregion

        #region Delete Employee
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) 
                return BadRequest();
            try
            {
                bool Deleted = _employeeService.DeleteEmployee(id);
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can not deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(String.Empty, "can not be empty");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return RedirectToAction("ErroorModel", ex);
                }
            }

        }
        #endregion
    }
}
