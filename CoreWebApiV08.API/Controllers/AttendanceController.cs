using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Classes;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IClasses classes;
        private readonly IMapper mapper;
        private readonly ImsContext imsContext;

        public AttendanceController(IClasses classes, IMapper mapper, ImsContext imsContext)
        {

            this.classes = classes;
            this.mapper = mapper;
            this.imsContext = imsContext;
        }

        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllAttendance()
        {
            var model = await classes.GetAllAttendanceAsync();

            return Ok(mapper.Map<List<AttendanceTypeDto>>(model));
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> AttendanceById([FromRoute] int id)
        {
            //get teacher domain from database      

            var Domain = await classes.GetAttendanceByIdAsync(id);

            //map domain model to dto

            if (Domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AttendanceTypeDto>(Domain));
        }
        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddAttendanceTypeRequestDto addAttendance)
        {
            var status = new Status();

            var model = mapper.Map<AttendanceTypeModel>(addAttendance);

            model = await classes.CreateAttendanceAsync(model);

            var attendanceDto = mapper.Map<AttendanceTypeDto>(model);

            if (attendanceDto.id > 0)
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
    }
}
