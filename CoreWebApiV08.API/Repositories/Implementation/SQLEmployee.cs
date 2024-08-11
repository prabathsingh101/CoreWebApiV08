using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Employees;
using CoreWebApiV08.API.Repositories.Interface;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLEmployee: IEmployee
    {
        private readonly DatabaseContext _context;
        public SQLEmployee(DatabaseContext context)
        {
            this._context = context;
        }
        public bool Add(EmployeeModel model)
        {
            try
            {
                _context.TblEmployee.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }        
    }
}
