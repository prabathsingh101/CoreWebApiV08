using AutoMapper;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Department;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Drawing2D;

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
        [Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var model = await department.GetAllAsync();

            return Ok(mapper.Map<List<DepartmentDto>>(model));
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] DepartmentDto departmentDto)
        {
            var status = new Status();

            var model = mapper.Map<Department>(departmentDto);

            model = await department.CreateAsync(model);

            var deptDto = mapper.Map<DepartmentDto>(model);

            if (deptDto.Id != 0)
            {
                status.StatusCode = 201;
                status.Message = "Data saved successfully.";
            }
            else
            {
                status.StatusCode = 204;
                status.Message = "No content found";
            }

            return Ok(deptDto);
        }


        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deptModel = await department.DeleteAsync(id);
            if (deptModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DepartmentDto>(deptModel));
        }


        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //get dept domain from database      

            var deptDomain = await department.GetByIdAsync(id);
            //map domain model to dto

            if (deptDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DepartmentDto>(deptDomain));
        }


        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                               [FromBody] UpdateDepartmentDto updateDepartmentDto)
        {
            //map dto to domain model
            var deptDomainModel = mapper.Map<Department>(updateDepartmentDto);

            //check dept if exists
            deptDomainModel = await department.UpdateAsync(id, deptDomainModel);

            if (deptDomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to dto
            return Ok(mapper.Map<DepartmentDto>(deptDomainModel));
        }
    }
}
