using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
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
    public class RegistrationController : ControllerBase
    {
        private readonly IStudentRegistration registration;
        private readonly IMapper mapper;
        private readonly ImsContext imsContext;

        public RegistrationController(IStudentRegistration registration, IMapper mapper, ImsContext imsContext)
        {
            this.registration = registration;
            this.mapper = mapper;
            this.imsContext = imsContext;
        }

        [HttpGet("GetAll")]
        //[Authorize(Roles = "Admin,User")]
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
            var model = await registration.GetAllAsync(
                filterOn, filterQuery, sortBy,
                isAscending ?? true, pageNumber, pageSize
                );

            return Ok(mapper.Map<List<RegistrationDto>>(model));
        }

        [HttpGet("{id:int}")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //get teacher domain from database      

            var domain = await registration.GetByIdAsync(id);

            //map domain model to dto

            if (domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegistrationDto>(domain));
        }

        [HttpPost]
        [Route("Create")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddRequestRegistrationDto addRequestRegistrationDto)
        {
            var status = new Status();

            var model = mapper.Map<StudentRegistrationModel>(addRequestRegistrationDto);

            model = await registration.CreateAsync(model);

            var teacherDto = mapper.Map<RegistrationDto>(model);

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
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var model = await registration.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegistrationDto>(model));
        }

        [HttpPut]
        [Route("{id:int}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                               [FromBody] UpdateRequestRegistrationDto updateRequestRegistrationDto)
        {
            //map dto to domain model
            var DomainModel = mapper.Map<StudentRegistrationModel>(updateRequestRegistrationDto);

            //check dept if exists
            DomainModel = await registration.UpdateAsync(id, DomainModel);

            if (DomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to dto
            return Ok(mapper.Map<RegistrationDto>(DomainModel));
        }
        [HttpGet("getmaxregno")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> getmaxregno()
        {
            string sqlquery = "select ISNULL(max(registrationno),0) as registrationno from tblregistration";

            var data = await imsContext.getmaxregno.FromSqlRaw(sqlquery).ToListAsync();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("registrationdetails")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> getregistrationdetails()
        {
            string sqlquery = "select TblRegistration.id as id,TblRegistration.registrationno as registrationno,TblRegistration.fullname as fullname,TblRegistration.registrationdate as registrationdate,TblRegistration.registrationfees as registrationfees,TblRegistration.mobileno as mobileno,TblRegistration.address as address,TblRegistration.isDeleted as isdeleted,TblRegistration.isStatus as isstatus, TblClass.classname as classname from TblRegistration inner join TblClass on TblClass.id=TblRegistration.classid";

            var data = await imsContext.getregistrationdetails.FromSqlRaw(sqlquery).ToListAsync();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
