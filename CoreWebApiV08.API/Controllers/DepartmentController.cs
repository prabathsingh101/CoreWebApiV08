using AutoMapper;
using CoreWebApiV08.API.Models.DTO.Department;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment department;
        private readonly IMapper mapper;

        public DepartmentController(IDepartment department, IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Department")]
        [Authorize(Roles ="Admin")]
        public async Task <IActionResult> GetAll()
        {
            var model= await department.GetAllDeptsync();

            return Ok(mapper.Map<List<DepartmentDto>>(model));  
        }
            
    }
}
