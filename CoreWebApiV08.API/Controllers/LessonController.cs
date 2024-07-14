using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.DTO.Course;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.Lesson;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoreWebApiV08.API.Models.DTO.Lesson;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ImsContext imsContext;
        private readonly ILesson lesson;

        public LessonController(ILesson lesson, IMapper mapper, ImsContext imsContext)
        {
            this.lesson = lesson;
            this.mapper = mapper;
            this.imsContext = imsContext;
        }

        //[HttpGet]
        //[Route("{id:int}")]
        //[Authorize(Roles = "Admin")]
        //public IEnumerable<TblLession> GetClesson([FromRoute] int id)
        //{

        //    var models = imsContext.TblLessions.Where(l => l.CourseId == id);

        //    return models;

        //}

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllLesson()
        {

            var model = await lesson.GetAllAsync();

            return Ok(mapper.Map<List<CourseLessonDto>>(model));

        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {                 

            var domain = await lesson.GetByIdAsync(id);
           

            if (domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CourseLessonDto>(domain));
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddLessonRequestDto addLessonRequestDto)
        {
            var status = new Status();

            var domain = mapper.Map<CourseLessionModel>(addLessonRequestDto);


            domain = await lesson.CreateAsync(domain);


            var lessonDto = mapper.Map<CourseLessonDto>(domain);

            if (lessonDto.id > 0)
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
            var model = await lesson.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CourseLessonDto>(model));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                               [FromBody] UpdateLessonRequestDto updateLessonRequestDto)
        {
            var status = new Status();

            var domainModel = mapper.Map<CourseLessionModel>(updateLessonRequestDto);


            domainModel = await lesson.UpdateAsync(id, domainModel);

            if (domainModel == null)
            {
                return NotFound();
            }


            //return Ok(mapper.Map<CourseDto>(domainModel));

            var courseDto = mapper.Map<CourseLessonDto>(domainModel);

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
