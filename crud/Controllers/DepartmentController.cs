using crudapi.Models;
using crudapi.Models.ViewModels;
using crudapi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [Route("Department")]
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllDepartments();
            return View(departments);
        }

        public async Task<IActionResult> AddEdit(int DepartmentId)
        {
            var department = await _departmentRepository.GetDepartmentById(DepartmentId);
            if(department == null)
            {
                return View(new TblDepartment());
            }
            else
            {
                return View(department);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Save(DepartmentRequestModel department)
        {
            var result = await _departmentRepository.AddEditDepartment(department);
            return Json(result);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int DepartmentId)
        {
            var result = await _departmentRepository.DeleteDepartment(DepartmentId);
            return Json(result);
        }
    }
}
