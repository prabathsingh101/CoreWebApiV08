using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Employees;
using CoreWebApiV08.API.Repositories.Interface;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLEmployee : IEmployees
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly DatabaseContext dbContext;

        public SQLEmployee(
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            DatabaseContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }
        public async Task<EmployeeModel> CreateAsync(IFormFile file, EmployeeModel employee)
        {
            // 1- Upload the Image to API/Images
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{employee.FileName}{employee.FileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            // 2-Update the database
            // https://codepulse.com/images/somefilename.jpg
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{employee.FileName}{employee.FileExtension}";

            employee.Url = urlPath;

            await dbContext.TblEmployee.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return employee;
        }
    }
}
