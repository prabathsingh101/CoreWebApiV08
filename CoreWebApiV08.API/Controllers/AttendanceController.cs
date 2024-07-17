using AutoMapper;
using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Classes;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IClasses classes;
        private readonly IMapper mapper;
        private readonly ImsContext imsContext;
        private readonly DatabaseContext databaseContext;

        public AttendanceController(IClasses classes, IMapper mapper, ImsContext imsContext,
            DatabaseContext databaseContext)
        {

            this.classes = classes;
            this.mapper = mapper;
            this.imsContext = imsContext;
            this.databaseContext = databaseContext;
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
        [Route("AttendanceById/{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> AttendanceById([FromRoute] int id)
        {
            var Domain = await classes.GetAttendanceByIdAsync(id);

            if (Domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AttendanceTypeDto>(Domain));
        }
        [HttpGet]
        [Route("studentbyclassid/{id:int}")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> studentbyclassid([FromRoute] int id)
        {
            //var Domain = await classes.GetStudentByClassIdAsync(id);

            //if (Domain == null)
            //{
            //    return NotFound();
            //}

            //return Ok(mapper.Map<AdmissionDto>(Domain));

            string sqlquery = "select s.id,s.fullname,s.registrationno,c.id as classid from TblStudent s inner join TblClass c on c.id=s.classid where s.classid=@classid";
            SqlParameter parameter = new SqlParameter("@classid", id);
            var data = await imsContext.studentdetails.FromSqlRaw(sqlquery, parameter).ToListAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
            var Domain = await classes.GetStudentByClassIdAsync(id);

            if (Domain == null)
            {
                return NotFound();
            }

            return Ok(Domain);



            //var studentclasslist = await (from c in databaseContext.TblClass
            //                              join s in databaseContext.TblStudent
            //                              on c.id
            //                              equals s.classid
            //                              where s.classid == id
            //                              select new
            //                              {
            //                                  id = s.id,
            //                                  fullname = s.fullname,
            //                                  registrationno = s.registrationno,
            //                                  classid = c.id,
            //                                  classname = c.classname
            //                              })
            //           .ToListAsync();

            //return Ok(studentclasslist);

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
