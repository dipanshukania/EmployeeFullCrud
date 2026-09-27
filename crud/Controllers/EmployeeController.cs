using crudapi.Models.ViewModels;
using crudapi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        [Route("Employee")]
        public async Task<IActionResult> Index()
        {
            var result = await _employeeRepository.GetAllEmployees();
           
            return View(result);
        }


        public async Task<IActionResult> AddEdit(int EmployeeId)
        {
            var employee = await _employeeRepository.GetEmployeeById(EmployeeId);
            ViewBag.Department = await _departmentRepository.GetAllDepartments();
            if (employee == null)
            {
                return View();
            }
            else
            {
                return View(employee);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Save(EmployeeRequestModel employee)
        {
            var result =await  _employeeRepository.AddEditEmployee(employee);
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int EmployeeId)
        {
            var result = await _employeeRepository.DeleteEmployee(EmployeeId);
            return Ok(result);
        }
    }
}
