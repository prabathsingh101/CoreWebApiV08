﻿using AutoMapper;
using CoreWebApiV08.API.Models.Department;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Department;
using CoreWebApiV08.API.Models.DTO.Teacher;
using CoreWebApiV08.API.Models.Teachers;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher teacher;
        private readonly IMapper mapper;

        public TeacherController(ITeacher teacher, IMapper mapper)
        {
            this.teacher = teacher;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin,User")]
        // //GET:/api/teacher?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        public async Task<IActionResult> GetAll(
            [FromQuery]
            string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000
            )
        {
            var model = await teacher.GetAllAsync(
                filterOn, filterQuery, sortBy,
                isAscending ?? true, pageNumber, pageSize
                );

            return Ok(mapper.Map<List<TeacherDto>>(model));
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //get teacher domain from database      

            var teacherDomain = await teacher.GetByIdAsync(id);

            //map domain model to dto

            if (teacherDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TeacherDto>(teacherDomain));
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddTeacherRequestDto addTeacherRequestDto)
        {
            var status = new Status();

            var model = mapper.Map<TeacherModel>(addTeacherRequestDto);

            model = await teacher.CreateAsync(model);

            var teacherDto = mapper.Map<TeacherDto>(model);

            if (teacherDto.id > 0)
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
            var teacherModel = await teacher.DeleteAsync(id);
            if (teacherModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TeacherDto>(teacherModel));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                               [FromBody] UpdateTeacherRequestDto updateTeacherRequestDto)
        {
            //map dto to domain model
            var teacherDomainModel = mapper.Map<TeacherModel>(updateTeacherRequestDto);

            //check dept if exists
            teacherDomainModel = await teacher.UpdateAsync(id, teacherDomainModel);

            if (teacherDomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to dto
            return Ok(mapper.Map<TeacherDto>(teacherDomainModel));
        }
    }
}