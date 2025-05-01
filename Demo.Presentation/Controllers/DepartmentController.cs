using Demo.BusinessLogic.DataTransferObjescts.DepartmentDtos;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.Presentation.ViewModels.DepartmentViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentServce _departmentServce,ILogger<DepartmentController> _logger,IWebHostEnvironment _environment) : Controller
    {
        #region Index Action
        public IActionResult Index()
        {
            var Departments = _departmentServce.GetAllDepartments();

            return View(Departments);
        }
        #endregion

        #region Create Actions
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = _departmentServce.AddDepartment(departmentDto);
                    if (Result > 0)
                    {
                        //return View(nameof(Index));
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "can not be empty");
                        return View(departmentDto);
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(String.Empty, "can not be empty");
                        return View(departmentDto);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View(departmentDto);
                    }
                } 
            }
            else
            {
                return View(departmentDto);
            }
        }
        #endregion

        #region Details Actions
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            else
            {
                var department = _departmentServce.GetDepartmentById(id.Value);
                if (department is null)
                    return NotFound();
                else
                    return View(department);
            }
        }
        #endregion

        #region Edit Actions
        [HttpGet]
        public IActionResult Edit(int? id) { 
            if(!id.HasValue)
                return BadRequest();
            var department = _departmentServce.GetDepartmentById(id.Value);
            if(department is null)
                return NotFound();
            var departmentViewModel = new DepartmentEditViewModel()
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateCreation = department.CreatedOn
            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel viewModel) {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedDepartment = new UpdatedDepartmentDto()
                    {
                        Id = id,
                        Name = viewModel.Name,
                        Code = viewModel.Code,
                        Description = viewModel.Description,
                        DateOfCreation = viewModel.DateCreation
                    };
                    int Result = _departmentServce.UpdateDepartment(updatedDepartment);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can not be updated");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(String.Empty, "can not be empty");
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View("ErrorView",ex);
                    }
                }

            }
            return View(viewModel);
        }
        #endregion

        #region Delete Actions
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department=_departmentServce.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = _departmentServce.DeleteDepartment(id);
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department can not deleted");
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
