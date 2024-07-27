using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Classes;
using CoreWebApiV08.API.Models.DTO.FeesHead;
using CoreWebApiV08.API.Models.FeesHead;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        
        private readonly IClasses classes;
        private readonly IMapper mapper;
        private readonly ImsContext imsContext;
        private readonly IFeesHead feesHead;

        public ClassesController(IClasses classes, IMapper mapper, ImsContext imsContext, IFeesHead feesHead)
        {
           
            this.classes = classes;
            this.mapper = mapper;
            this.imsContext = imsContext;
            this.feesHead = feesHead;
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
            var model = await classes.GetAllAsync(
                filterOn, filterQuery, sortBy,
                isAscending ?? true, pageNumber, pageSize
                );

            return Ok(mapper.Map<List<ClassesDto>>(model));
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //get teacher domain from database      

            var Domain = await classes.GetByIdAsync(id);

            //map domain model to dto

            if (Domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ClassesDto>(Domain));
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddClassRequestDto addClassRequestDto)
        {
            var status = new Status();

            var model = mapper.Map<Classes>(addClassRequestDto);

            model = await classes.CreateAsync(model);

            var classesDto = mapper.Map<ClassesDto>(model);

            if (classesDto.id > 0)
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
            var model = await classes.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ClassesDto>(model));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                               [FromBody] UpdateClassRequestDto updateClassRequestDto)
        {
            //map dto to domain model
            var DomainModel = mapper.Map<Classes>(updateClassRequestDto);

            //check dept if exists
            DomainModel = await classes.UpdateAsync(id, DomainModel);

            if (DomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to dto
            return Ok(mapper.Map<ClassesDto>(DomainModel));
        }

        [HttpGet("getclassdetail")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> getClass()
        {
            string sqlquery = "exec sp_getClassDetails";

            var data = await imsContext.getclassdetails.FromSqlRaw(sqlquery).ToListAsync();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("classname")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> getClassName()
        {
            string sqlquery = "exec sp_getClassName";

            var data = await imsContext.getclassname.FromSqlRaw(sqlquery).ToListAsync();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpGet]
        [Route("getfeeshead")]
        public async Task<IActionResult> getfeeshead()
        {
            var model = await feesHead.GetAllAsync();
               

            return Ok(mapper.Map<List<FeesHeadDto>>(model));
        }

        [HttpGet("getbyidfeeshead/{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> getbyidfeeshead([FromRoute] int id)
        {
            //get teacher domain from database      

            var Domain = await feesHead.GetByIdAsync(id);

            //map domain model to dto

            if (Domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<FeesHeadDto>(Domain));
        }

        [HttpGet("getfeenamebyclassid/{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> getfeenamebyclassid([FromRoute] int id)
        {                 

            var Domain = await feesHead.GetFeenameByClassIdAsync(id);
            

            if (Domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<FeesHeadDto>(Domain));
        }


        [HttpPost]
        [Route("createfeeshead")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> createfeeshead([FromBody] AddFeesHeadRequestDto addFeesHeadRequestDto)
        {
            var status = new Status();

            var model = mapper.Map<FeesHeadModel>(addFeesHeadRequestDto);

            model = await feesHead.CreateAsync(model);

            var feesheadDto = mapper.Map<FeesHeadDto>(model);

            if (feesheadDto == null)
            {
                status.StatusCode = 203;
                status.Message = "Fees head is already exists for this class.";
            }

            else if (feesheadDto.id > 0)
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
        [Route("deletefeeshead/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> deletefeeshead([FromRoute] int id)
        {
            var model = await feesHead.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<FeesHeadDto>(model));
        }

        [HttpPut]
        [Route("updatefeeshead/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> updatefeeshead([FromRoute] int id,
                                               [FromBody] UpdateFeesHeadRequestDto updateFeesHeadRequestDto)
        {
            //map dto to domain model
            var DomainModel = mapper.Map<FeesHeadModel>(updateFeesHeadRequestDto);

            //check dept if exists
            DomainModel = await feesHead.UpdateAsync(id, DomainModel);

            if (DomainModel == null)
            {
                return NotFound();
            }

            //convert domain model to dto
            return Ok(mapper.Map<FeesHeadDto>(DomainModel));
        }

        [HttpGet]
        [Route("getfeenamelistbyclass/{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> getfeenamelistbyclass([FromRoute] int id)
        {

            string sqlquery = "select id, classid, feename from TblFeesHead where classid=@id";
            SqlParameter parameter = new SqlParameter("@id", id);
            var data = await imsContext.mapfeenames.FromSqlRaw(sqlquery, parameter).ToListAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
