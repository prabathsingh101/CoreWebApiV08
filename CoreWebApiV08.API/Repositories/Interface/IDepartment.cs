using CoreWebApiV08.API.Models.Department;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IDepartment
    {
        Task<List<Department>> GetAllDeptsync();
    }
}
