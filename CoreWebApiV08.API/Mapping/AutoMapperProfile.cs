using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.DTO.Course;
using CoreWebApiV08.API.Models.DTO.Department;
using CoreWebApiV08.API.Models.DTO.Lesson;

namespace CoreWebApiV08.API.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<AddDepartmentDto, Department>().ReverseMap();
            CreateMap<UpdateDepartmentDto, Department>().ReverseMap();

            CreateMap<CourseModel, CourseDto>().ReverseMap();


            CreateMap<TblLession, CourseLessonDto>().ReverseMap();
        }
    }
}
