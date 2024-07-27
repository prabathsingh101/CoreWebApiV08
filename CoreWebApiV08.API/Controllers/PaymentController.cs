using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.FeesHead;
using CoreWebApiV08.API.Models.FeesHead;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ImsContext imsContext;
        private readonly IMapper mapper;
        private readonly IPayment payment;

        public PaymentController(ImsContext imsContext, IMapper mapper, IPayment payment )
        {
            this.imsContext = imsContext;
            this.mapper = mapper;
            this.payment = payment;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCourse()
        {

            var model = await payment.GetAllAsync();

            return Ok(mapper.Map<List<PaymentDto>>(model));

        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {            

            var domain = await payment.GetByIdAsync(id);
           

            if (domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PaymentDto>(domain));
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddPaymentRequestDto addPaymentRequestDto)
        {
            var status = new Status();

            var domainModel = mapper.Map<PaymentModels>(addPaymentRequestDto);


            domainModel = await payment.CreateAsync(domainModel);


            var courseDto = mapper.Map<PaymentDto>(domainModel);

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
            var model = await payment.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PaymentDto>(model));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                               [FromBody] UpdatePaymentRequestDto updatePaymentRequestDto)
        {
            var status = new Status();

            var domainModel = mapper.Map<PaymentModels>(updatePaymentRequestDto);

            domainModel = await payment.UpdateAsync(id, domainModel);

            if (domainModel == null)
            {
                return NotFound();
            }
           
            var courseDto = mapper.Map<PaymentDto>(domainModel);

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
