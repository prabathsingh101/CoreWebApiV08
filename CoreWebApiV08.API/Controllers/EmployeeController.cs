using AutoMapper;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Classes;
using CoreWebApiV08.API.Models.DTO.Emoloyees;
using CoreWebApiV08.API.Models.Employees;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IFileService fs;
        private readonly IEmployee iemployee;
        private readonly IMapper mapper;

        public EmployeeController(IFileService fs, IEmployee Iemployee, IMapper mapper)
        {
            this.fs = fs;
            iemployee = Iemployee;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("create")]
        [Produces("application/json")]
        public IActionResult Add([FromForm] AddEmployeeRequestDto addEmployeeRequestDto)
        {
            var status = new Status();

            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if (addEmployeeRequestDto.imagefile != null)
            {
                var fileResult = fs.SaveImage(addEmployeeRequestDto.imagefile);

                if (fileResult.Item1 == 1)
                {
                    addEmployeeRequestDto.employeeimage = fileResult.Item2; // getting name of image
                }

                var model = mapper.Map<EmployeeModel>(addEmployeeRequestDto);

                var productResult = iemployee.Add(model);

                //var empDto = mapper.Map<EmployeesDto>(productResult);

                if (productResult)
                {
                    status.StatusCode = 1;
                    status.Message = "Added successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error on adding product";

                }
            }
            return Ok(status);
        }
    }
}
