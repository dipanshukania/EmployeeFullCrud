using crudapi.Models.ViewModels;
using crudapi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace crudapi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("api/GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            CommonResponseModel res = new CommonResponseModel();
            var result = await _employeeRepository.GetAllEmployees();
            res.Success = true;
            res.Message = "Data fetched Successfully";
            res.data = result;

            return Ok(result);
        }

        [HttpGet("api/GetEmployeeById")]

        public async Task<IActionResult> GetEmployeeById(int EmployeeId)
        {
            CommonResponseModel res = new CommonResponseModel();
            var result = await _employeeRepository.GetEmployeeById(EmployeeId);
            res.Success = true;
            res.Message = "Data fetched Successfully";
            res.data = result;

            return Ok(result);
        }

        [HttpPost("api/AddEditEmployee")]
        public async Task<IActionResult> AddEditEmployee(EmployeeRequestModel employee)
        {
            var result = await _employeeRepository.AddEditEmployee(employee);
            return Ok(result);
        }

        [HttpDelete("api/DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee (int EmployeeId)
        {
            var result = await _employeeRepository.DeleteEmployee(EmployeeId);
            return Ok(result);
        }

    }
}
