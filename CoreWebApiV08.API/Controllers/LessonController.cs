using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Lesson;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IEnumerable<TblLession> GetClesson([FromRoute] int id)
        {
            List<CourseLession> _list = new List<CourseLession>();

            var models = imsContext.TblLessions.Where(l => l.CourseId == id);


            return models;

            //List<CourseLession> _list = new List<CourseLession>();

            //var _lession = imsContext.TblLessions.FirstOrDefault(item => item.CourseId == id);

            //if (_lession != null)
            //{     

            //    foreach (var item in _list)
            //    {

            //        _list.Add(new CourseLession()
            //        {
            //            Id = _lession.Id,
            //            description = _lession.Description,
            //            duration = _lession.Duration,
            //            seqNo = _lession.SeqNo,
            //            CourseId = _lession.CourseId
            //        });
            //    }
            //}

            //return _list;
        }
    }
}
