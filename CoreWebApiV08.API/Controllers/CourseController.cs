using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.DTO.Course;
using CoreWebApiV08.API.Models.DTO.Lesson;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ImsContext imsContext;
        private readonly IMapper mapper;
        private readonly ICourse course;
        private readonly ILesson lesson;

        public CourseController(ImsContext imsContext, IMapper mapper, ICourse course, ILesson lesson)
        {
            this.imsContext = imsContext;
            this.mapper = mapper;
            this.course = course;
            this.lesson = lesson;
        }

        [HttpGet]
        [Route("GetClass")]
        [Authorize(Roles ="Admin")]
        public IEnumerable<TblClass> GetClass() {

            var SPs = "spGetClass";

            var queries = "SELECT 0 as ClassId,'--Select Class--' as Name union SELECT ClassId,Name FROM TblClass  WITH(NOLOCK)";

            return  imsContext.TblClasses.FromSqlRaw(SPs).ToList();

        }

        [HttpGet]
        [Route("GetAllCourse")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCourse()
        {

          var model= await course.GetAllCourseAsync();

            return Ok(mapper.Map<List<CourseDto>>(model));

        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //get region domain from database      

            var courseDomain = await course.GetByIdAsync(id);
            //map domain model to dto

            if (courseDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CourseDto>(courseDomain));
        }

      

    }
}
