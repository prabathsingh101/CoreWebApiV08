using CoreWebApiV08.API.Models.DTO.Emoloyees;
using CoreWebApiV08.API.Models.Employees;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployees employees;

        public EmployeesController(IEmployees employees)
        {
            this.employees = employees;
        }

        // POST: {apibaseurl}/api/images
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEmployee([FromForm] IFormFile file,
            [FromForm] string fname, [FromForm] string lname)
        {
            ValidateFileUpload(file);

            if (ModelState.IsValid)
            {
                // File upload
                var employeeModel = new EmployeeModel
                {
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),                                     
                    fname = fname,
                    lname = lname,
                };

                employeeModel = await employees.CreateAsync(file, employeeModel);

                // Convert Domain Model to DTO
                var response = new EmployeesDto
                {
                    id = employeeModel.id,                   
                    createddate = employeeModel.createddate,
                    FileExtension = employeeModel.FileExtension,
                    FileName = employeeModel.FileName,
                    Url = employeeModel.Url
                };

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB");
            }
        }
    }
}
