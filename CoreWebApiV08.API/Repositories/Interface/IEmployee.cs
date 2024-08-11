using CoreWebApiV08.API.Models.Employees;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IEmployee
    {
        bool Add(EmployeeModel model);
    }
}
