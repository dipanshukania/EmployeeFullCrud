using crudapi.Models;
using crudapi.Models.ViewModels;

namespace crudapi.Repository.Interface
{
    public interface IDepartmentRepository
    {
        Task<List<TblDepartment>> GetAllDepartments();

        Task<TblDepartment> GetDepartmentById(int DepartmentId);

        Task<CommonResponseModel> AddEditDepartment(DepartmentRequestModel department);

        Task<CommonResponseModel> DeleteDepartment(int DepartmentId);
    }
}
