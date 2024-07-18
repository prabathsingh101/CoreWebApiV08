using AutoMapper;
using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Attendance;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Attendance;
using CoreWebApiV08.API.Models.DTO.Classes;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IClasses classes;
        private readonly IMapper mapper;
        private readonly ImsContext imsContext;
        private readonly IAttendance attendance;
        private readonly DatabaseContext databaseContext;

        public AttendanceController(IClasses classes, IMapper mapper, ImsContext imsContext,
            IAttendance attendance,
            DatabaseContext databaseContext)
        {

            this.classes = classes;
            this.mapper = mapper;
            this.imsContext = imsContext;
            this.attendance = attendance;
            this.databaseContext = databaseContext;
        }

        //[HttpGet]
        //[Route("all")]
        //[Authorize(Roles = "Admin,User")]
        //public async Task<IActionResult> GetAllAttendance()
        //{
        //    var model = await classes.GetAllAttendanceAsync();

        //    return Ok(mapper.Map<List<AttendanceTypeDto>>(model));
        //}

        //[HttpGet]
        //[Route("AttendanceById/{id:int}")]
        //[Authorize(Roles = "Admin,User")]
        //public async Task<IActionResult> AttendanceById([FromRoute] int id)
        //{
        //    var Domain = await classes.GetAttendanceByIdAsync(id);

        //    if (Domain == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(mapper.Map<AttendanceTypeDto>(Domain));
        //}


        [HttpGet]
        [Route("studentbyclassid/{id:int}")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> studentbyclassid([FromRoute] int id)
        {           

            string sqlquery = "select s.id as studentid,s.fullname,s.registrationno,c.id as classid from TblStudent s inner join TblClass c on c.id=s.classid where s.classid=@classid";
            SqlParameter parameter = new SqlParameter("@classid", id);
            var data = await imsContext.studentdetails.FromSqlRaw(sqlquery, parameter).ToListAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);           


        }


        [HttpPost]
        [Route("create")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] List<AddAttendanceRequestDto> addAttendance)
        {
            
            var status = new Status();

            foreach (var item in addAttendance) {
                var attendanceData = new AttendanceTypeModel { 
                    classid = item.classid,
                    date= item.date,
                    studentid = item.studentid,
                    isSelected = item.isSelected,
                    type = item.type,
                };
               var mydata= mapper.Map<AttendanceTypeModel>(attendanceData);

                mydata = await attendance.CreateAsync(mydata);
                var attendanceDto = mapper.Map<AttendanceDto>(mydata);
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
            }      

            return Ok(status);
        }
    }
}
