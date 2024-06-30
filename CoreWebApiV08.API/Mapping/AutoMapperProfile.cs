using AutoMapper;
using System.Drawing.Drawing2D;
using System.Drawing;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.DTO.Department;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.DTO.Course;
using CoreWebApiV08.API.Models.Lesson;
using CoreWebApiV08.API.Models.DTO.Lesson;
using CoreWebApiV08.API.DBFirstModel;

namespace CoreWebApiV08.API.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<CourseModel, CourseDto>().ReverseMap();
            CreateMap<TblLession, CourseLessonDto>().ReverseMap();
        }
    }
}
