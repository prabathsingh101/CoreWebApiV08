using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Course;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Authorize(Roles = "Admin")]
        public IEnumerable<TblClass> GetClass()
        {

            var SPs = "spGetClass";

            var queries = "SELECT 0 as ClassId,'--Select Class--' as Name union SELECT ClassId,Name FROM TblClass  WITH(NOLOCK)";

            return imsContext.TblClasses.FromSqlRaw(SPs).ToList();

        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCourse()
        {

          var model= await course.GetAllAsync();

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

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddCourseRequestDto addCourseRequestDto)
        {
            var status = new Status();

            var domainModel = mapper.Map<CourseModel>(addCourseRequestDto);

           
            domainModel = await course.CreateAsync(domainModel);

            
            var courseDto = mapper.Map<CourseDto>(domainModel);

            if (courseDto.id > 0)
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
            var model = await course.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CourseDto>(model));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                               [FromBody] UpdateCourseRequestDto updateCourseRequestDto)
        {
            var status = new Status();

            var domainModel = mapper.Map<CourseModel>(updateCourseRequestDto);


            domainModel = await course.UpdateAsync(id, domainModel);

            if (domainModel == null)
            {
                return NotFound();
            }


            //return Ok(mapper.Map<CourseDto>(domainModel));
            var courseDto = mapper.Map<CourseDto>(domainModel);

            if (courseDto.id > 0)
            {
                status.StatusCode = 200;
                status.Message = "Data updated successfully.";
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
