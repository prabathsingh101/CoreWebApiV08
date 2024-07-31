using AutoMapper;
using Azure.Core;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Admission;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Classes;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent student;
        private readonly IMapper mapper;
        private readonly ImsContext imsContext;

        public StudentController(IStudent student, IMapper mapper, ImsContext imsContext)
        {
            this.student = student;
            this.mapper = mapper;
            this.imsContext = imsContext;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin, User")]
        // //GET:/api/teacher?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        public async Task<IActionResult> GetAll(
            [FromQuery]
            string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000
            )
        {
            var model = await student.GetAllAsync(
                filterOn, filterQuery, sortBy,
                isAscending ?? true, pageNumber, pageSize
                );

            return Ok(mapper.Map<List<AdmissionDto>>(model));
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //get teacher domain from database      

            var domain = await student.GetByIdAsync(id);

            //map domain model to dto

            if (domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AdmissionDto>(domain));
        }

        [HttpGet("getstudentbyclass/{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GettudentByClasId([FromRoute] int id)        
        {               

            var domain = await student.GetAllStudentByClass(id);
           

            if (domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<AdmissionDto>>(domain));
        }


        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddAdmissionRequestDto addAdmissionRequestDto)
        {
            
            var status = new Status();

            var model = mapper.Map<StudentAdmissionModel>(addAdmissionRequestDto);

            model = await student.CreateAsync(model);

            var teacherDto = mapper.Map<AdmissionDto>(model);

            if (teacherDto.id > 0)
            {
                status.StatusCode = 201;
                status.Message = "Data saved successfully.";
            }
            else
            {
                status.StatusCode = 204;
                status.Message = "No content found";
            }

            return Ok(status);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var model = await student.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AdmissionDto>(model));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                               [FromBody] UpdateAdmissionRequestDto updateAdmissionRequestDto)
        {
            //map dto to domain model
            var DomainModel = mapper.Map<StudentAdmissionModel>(updateAdmissionRequestDto);

            //check dept if exists
            DomainModel = await student.UpdateAsync(id, DomainModel);

            if (DomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to dto
            return Ok(mapper.Map<AdmissionDto>(DomainModel));
        }

        [HttpGet]
        [Route("totalstudent")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> TotalStudent()
        {
            string sqlquery = "select count(id) as totalstudent from TblStudent";
            var data = await imsContext.totalstudent.FromSqlRaw(sqlquery).ToListAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        
        
        [HttpPatch]
        [Route("partialupdate/{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> PartialUpdate([FromRoute] int id,
                                               [FromBody] UpdateAdmissionRequestDto updateAdmissionRequestDto)
        {
            
            var DomainModel = mapper.Map<StudentAdmissionModel>(updateAdmissionRequestDto);

           
            DomainModel = await student.PartialUpdateAsync(id, DomainModel);

            if (DomainModel == null)
            {
                return NotFound();
            }

           
            return Ok(mapper.Map<AdmissionDto>(DomainModel));
        }
    }
}
