using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Holidays;
using CoreWebApiV08.API.Models.Holidays;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidays holidays;
        private readonly IMapper mapper;
        private readonly ImsContext imsContext;

        public HolidaysController(IHolidays holidays, IMapper mapper, ImsContext imsContext)
        {
            this.holidays = holidays;
            this.mapper = mapper;
            this.imsContext = imsContext;
        }

        [HttpPost]
        [Route("Post")]
        [Authorize(Roles = "Admin")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] AddRequestHolidaysDto addRequestHolidaysDto)
        {
            var status = new Status(); 

            var model = mapper.Map<HolidaysModel>(addRequestHolidaysDto);

            model = await holidays.CreateAsync(model);

            var holidayDto = mapper.Map<AddRequestHolidaysDto>(model);

            status.StatusCode = 201;
            status.Message = "Data saved successfully.";

            return Ok(status);  
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        [Produces("application/json")]
        public async Task<IActionResult> Update(
            [FromRoute] int id, 
            [FromBody] UpdateRequestHolidaysDto 
            updateHolidaysRequestDto)
        {
            
            var holidayDomainModel = mapper.Map<HolidaysModel>(updateHolidaysRequestDto);
           
            holidayDomainModel = await holidays.UpdateAsync(id,holidayDomainModel);

            if (holidayDomainModel == null)
            {
                return NotFound();
            }
            
            return Ok(mapper.Map<HolidaysDto>(holidayDomainModel));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin,User")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {

            var holidayDomainModel = await holidays.GetAllAsync();

            if(holidayDomainModel == null)return NotFound();

            return Ok(mapper.Map<List<HolidaysDto>>(holidayDomainModel));
           
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin,User")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var holidayDomainModel = await holidays.GetByIdAsync(id);

            if (holidayDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<HolidaysDto>(holidayDomainModel));

        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
          var holidayModel =await holidays.DeleteAsync(id);
            if (holidayModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<HolidaysDto>(holidayModel));
        }

        [HttpGet("getevents")]
        [Authorize(Roles = "Admin,User")]
        [Produces("application/json")]
        public async Task<IActionResult> getHolidayEvents()
        {
            string sqlquery = "exec sp_getHolidaysEvent";

            var data = await imsContext.getholidayevents.FromSqlRaw(sqlquery).ToListAsync();

            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);    
        }

        [AcceptVerbs("GET", "POST","PUT","DELETE")]
        [Produces("application/json")]
        public IActionResult MyAction()
        {            
            return Ok();
        }
    }
}
