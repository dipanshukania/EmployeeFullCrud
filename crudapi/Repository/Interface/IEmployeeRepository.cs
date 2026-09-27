using crudapi.Models;
using crudapi.Models.ViewModels;

namespace crudapi.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<TblEmployee>> GetAllEmployees();

        Task<TblEmployee> GetEmployeeById(int EmployeeId);

        Task<CommonResponseModel> AddEditEmployee(EmployeeRequestModel employee);

        Task<CommonResponseModel> DeleteEmployee(int EmployeeId);
    }
}
