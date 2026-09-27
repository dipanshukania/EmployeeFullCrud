using crudapi.Models;
using crudapi.Models.ViewModels;
using crudapi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace crudapi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;


        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<CommonResponseModel> AddEditEmployee(EmployeeRequestModel employee)
        {
            CommonResponseModel res = new CommonResponseModel();
            var result = await _context.ServerResponseModels.FromSqlInterpolated($"EXECUTE dbo.AddEditEmployee @Id = {employee?.Id},@Name = {employee.Name},@Email={employee.Email},@Phone={employee.Phone},@Salary={employee.Salary},@Gender={employee.Gender},@Description={employee.Description},@IsActive={employee.IsActive},@DepartmentId={employee.DepartmentId}")
                .AsAsyncEnumerable().FirstOrDefaultAsync();

            if(result == null)
            {
                res.Success = false;
                res.Message = "Something Went Wrong";
            }
            else
            {
                res.Success = result.Success;
                res.Message = result.Message;
            }
            return res;
        }

        public async Task<CommonResponseModel> DeleteEmployee(int EmployeeId)
        {
            CommonResponseModel res = new CommonResponseModel();
            var Employee = await _context.TblEmployees.Where(x => x.Id == EmployeeId).FirstOrDefaultAsync();
            if(Employee == null)
            {
                res.Success = false;
                res.Message = "No Employee found";
            }
            else
            {
                _context.TblEmployees.Remove(Employee);
                await _context.SaveChangesAsync();

                res.Success = true;
                res.Message = "Employee Deleted Succesfully";
            }
            return res;
        }

        public async Task<List<TblEmployee>> GetAllEmployees()
        {
            return await _context.TblEmployees.AsNoTracking().ToListAsync();
        }

        public async Task<TblEmployee> GetEmployeeById(int EmployeeId)
        {
            return await _context.TblEmployees.AsNoTracking().Where(x => x.Id == EmployeeId).FirstOrDefaultAsync();
        }
    }
}
