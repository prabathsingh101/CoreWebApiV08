using CoreWebApiV08.API.Models.Department;
using System.Drawing;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IDepartment
    {
        Task<List<Department>> GetAllAsync();

        Task<Department?> GetByIdAsync(int id);

        Task<Department> CreateAsync(Department department);

        Task<Department?> UpdateAsync(int id, Department department);

        Task<Department?> DeleteAsync(int id);
    }
}
