using crudapi.Models;
using crudapi.Models.ViewModels;
using crudapi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace crudapi.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("api/GetAllDepartments")]

        public async Task<IActionResult> GetAllDepartments()
        {
            CommonResponseModel res = new CommonResponseModel();

            var result =await  _departmentRepository.GetAllDepartments();

            res.Success = true;
            res.Message = "Data Fetched Successfully";
            res.data = result;

            return Ok(res);
        }

        [HttpGet("api/GetDepartmentById")]

        public async Task<IActionResult> GetDepartmentById(int DepartmentId)
        {
            CommonResponseModel res = new CommonResponseModel();

            var result = await _departmentRepository.GetDepartmentById(DepartmentId);

            res.Success = true;
            res.Message = "Data Fetched Successfully";
            res.data = result;

            return Ok(res);
        }

        [HttpPost("api/AddEditDepartment")]
        public async Task<IActionResult> AddEditDepartment([FromBody] DepartmentRequestModel department)
        {
            var result = await _departmentRepository.AddEditDepartment(department);
            return Ok(result);
        }

        [HttpDelete("api/DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int DepartmentId)
        {
            var result = await _departmentRepository.DeleteDepartment(DepartmentId);
            return Ok(result);
        }
    }
}
