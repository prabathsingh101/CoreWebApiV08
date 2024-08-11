using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Admission;
using CoreWebApiV08.API.Models.Attendance;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.DTO.Attendance;
using CoreWebApiV08.API.Models.DTO.Classes;
using CoreWebApiV08.API.Models.DTO.Course;
using CoreWebApiV08.API.Models.DTO.Department;
using CoreWebApiV08.API.Models.DTO.Emoloyees;
using CoreWebApiV08.API.Models.DTO.FeesHead;
using CoreWebApiV08.API.Models.DTO.Holidays;
using CoreWebApiV08.API.Models.DTO.Lesson;
using CoreWebApiV08.API.Models.DTO.Teacher;
using CoreWebApiV08.API.Models.Employees;
using CoreWebApiV08.API.Models.FeesHead;
using CoreWebApiV08.API.Models.Holidays;
using CoreWebApiV08.API.Models.Lesson;
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
            CreateMap<AddCourseRequestDto, CourseModel>().ReverseMap();
            CreateMap<UpdateCourseRequestDto, CourseModel>().ReverseMap();


            CreateMap<LessionModel, LessonDto>().ReverseMap();
            CreateMap<AddLessonRequestDto, LessionModel>().ReverseMap();
            CreateMap<UpdateLessonRequestDto, LessionModel>().ReverseMap();


            CreateMap<HolidaysModel, HolidaysDto>().ReverseMap();
            CreateMap<AddRequestHolidaysDto, HolidaysModel>().ReverseMap();
            CreateMap<UpdateRequestHolidaysDto, HolidaysModel>().ReverseMap();


            CreateMap<TeacherModel, TeacherDto>().ReverseMap();
            CreateMap<AddTeacherRequestDto, TeacherModel>().ReverseMap();
            CreateMap<UpdateTeacherRequestDto, TeacherModel>().ReverseMap();

            CreateMap<Classes, ClassesDto>().ReverseMap();
            CreateMap<AddClassRequestDto, Classes>().ReverseMap();
            CreateMap<UpdateClassRequestDto, Classes>().ReverseMap();


            CreateMap<StudentRegistrationModel, RegistrationDto>().ReverseMap();
            CreateMap<AddRequestRegistrationDto, StudentRegistrationModel>().ReverseMap();
            CreateMap<UpdateRequestRegistrationDto, StudentRegistrationModel>().ReverseMap();

            CreateMap<StudentAdmissionModel, AdmissionDto>().ReverseMap();
            CreateMap<AddAdmissionRequestDto, StudentAdmissionModel>().ReverseMap();
            CreateMap<UpdateAdmissionRequestDto, StudentAdmissionModel>().ReverseMap();

            CreateMap<AttendanceTypeModel, AttendanceDto>().ReverseMap();
            CreateMap<AddAttendanceRequestDto, AttendanceTypeModel>().ReverseMap();
            CreateMap<UpdateAttendanceRequestDto, AttendanceTypeModel>().ReverseMap();


            CreateMap<FeesHeadModel, FeesHeadDto>().ReverseMap();
            CreateMap<AddFeesHeadRequestDto, FeesHeadModel>().ReverseMap();
            CreateMap<UpdateFeesHeadRequestDto, FeesHeadModel>().ReverseMap();


            CreateMap<PaymentModels, PaymentDto>().ReverseMap();
            CreateMap<AddPaymentRequestDto, PaymentModels>().ReverseMap();
            CreateMap<UpdatePaymentRequestDto, PaymentModels>().ReverseMap();


            CreateMap<PartialStudentAdmissionModel, PartialStudentAdmissionDto>().ReverseMap();
            CreateMap<PartialUpdateStudentAdmissionDto, PartialStudentAdmissionModel>().ReverseMap();


            CreateMap<EmployeeModel, EmployeesDto>().ReverseMap();
            CreateMap<AddEmployeeRequestDto, EmployeeModel>().ReverseMap();
        }
    }
}
