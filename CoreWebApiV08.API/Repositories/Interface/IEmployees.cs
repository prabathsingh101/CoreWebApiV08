using CoreWebApiV08.API.Models.Employees;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IEmployees
    {
        Task<EmployeeModel> CreateAsync(IFormFile file, EmployeeModel employee);
    }
}
