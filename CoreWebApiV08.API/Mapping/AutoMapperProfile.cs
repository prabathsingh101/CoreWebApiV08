using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.DTO.Classes;
using CoreWebApiV08.API.Models.DTO.Course;
using CoreWebApiV08.API.Models.DTO.Department;
using CoreWebApiV08.API.Models.DTO.Holidays;
using CoreWebApiV08.API.Models.DTO.Lesson;
using CoreWebApiV08.API.Models.DTO.Teacher;
using CoreWebApiV08.API.Models.Holidays;
using CoreWebApiV08.API.Models.Teachers;

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


            CreateMap<HolidaysModel, HolidaysDto>().ReverseMap();
            CreateMap<AddRequestHolidaysDto, HolidaysModel>().ReverseMap();
            CreateMap<UpdateRequestHolidaysDto, HolidaysModel>().ReverseMap();


            CreateMap<TeacherModel, TeacherDto>().ReverseMap();
            CreateMap<AddTeacherRequestDto, TeacherModel>().ReverseMap();
            CreateMap<UpdateTeacherRequestDto, TeacherModel>().ReverseMap();

            CreateMap<Classes, ClassesDto>().ReverseMap();
            CreateMap<AddClassRequestDto, Classes>().ReverseMap();
            CreateMap<UpdateClassRequestDto, Classes>().ReverseMap();


            CreateMap<StudentRegistration, RegistrationDto>().ReverseMap();
            CreateMap<AddRequestRegistrationDto, StudentRegistration>().ReverseMap();
            CreateMap<UpdateRequestRegistrationDto, StudentRegistration>().ReverseMap();

            CreateMap<StudentAdmissionModel, AdmissionDto>().ReverseMap();
            CreateMap<AddAdmissionRequestDto, StudentAdmissionModel>().ReverseMap();
            CreateMap<UpdateAdmissionRequestDto, StudentAdmissionModel>().ReverseMap();
        }
    }
}
