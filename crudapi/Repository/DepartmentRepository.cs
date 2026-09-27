using crudapi.Models;
using crudapi.Models.ViewModels;
using crudapi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace crudapi.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<CommonResponseModel> AddEditDepartment(DepartmentRequestModel department)
        {
            CommonResponseModel res = new CommonResponseModel();

            var result = await _context.ServerResponseModels.FromSqlInterpolated($"EXECUTE dbo.AddEditDepartment @DepartmentId = {department.DepartmentId},@DepartmentName={department.DepartmentName}").
                AsAsyncEnumerable().FirstOrDefaultAsync();

            if(result == null)
            {
                res.Success = false;
                res.Message = "Something went wrong";
            }
            else
            {
                res.Success = result.Success;
                res.Message = result.Message;

            }
            return res;
        }

        public async Task<CommonResponseModel> DeleteDepartment(int DepartmentId)
        {
            CommonResponseModel res = new CommonResponseModel();
            var Department = await _context.TblDepartments.Where(x => x.DepartmentId == DepartmentId).FirstOrDefaultAsync();
            if(Department == null)
            {
                res.Success = false;
                res.Message = "No Department Found";
            }
            else
            {
                _context.TblDepartments.Remove(Department);
                await _context.SaveChangesAsync();

                res.Success = true;
                res.Message = "Department Deleted Successfully";
            }
            return res;
        }

        public async Task<List<TblDepartment>> GetAllDepartments()
        {
            return await _context.TblDepartments.AsNoTracking().ToListAsync();
        }

        public async Task<TblDepartment> GetDepartmentById(int DepartmentId)
        {
            return await _context.TblDepartments.AsNoTracking().Where(x => x.DepartmentId == DepartmentId).FirstOrDefaultAsync();
        }
    }
}
