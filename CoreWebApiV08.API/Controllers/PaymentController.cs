using AutoMapper;
using CoreWebApiV08.API.DBFirstModel;
using CoreWebApiV08.API.Models.Attendance;
using CoreWebApiV08.API.Models.DTO;
using CoreWebApiV08.API.Models.DTO.Attendance;
using CoreWebApiV08.API.Models.DTO.FeesHead;
using CoreWebApiV08.API.Models.FeesHead;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ImsContext imsContext;
        private readonly IMapper mapper;
        private readonly IPayment objPayment;

        public PaymentController(ImsContext imsContext, IMapper mapper, IPayment objPayment )
        {
            this.imsContext = imsContext;
            this.mapper = mapper;
            this.objPayment = objPayment;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCourse()
        {

            var model = await objPayment.GetAllAsync();

            return Ok(mapper.Map<List<PaymentDto>>(model));

        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {            

            var domain = await objPayment.GetByIdAsync(id);
           

            if (domain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PaymentDto>(domain));
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] List<AddPaymentRequestDto> addPaymentRequestDto)
        {
            var status = new Status();

            foreach (var payment in addPaymentRequestDto)
            {
                var paymentdata = new PaymentModels
                {
                    isselected = payment.isselected,
                    classid = payment.classid,
                    studentid = payment.studentid,
                    paymenttype = payment.paymenttype,
                    collectiondate = payment.collectiondate,
                    invoiceno = payment.invoiceno,
                    feename = payment.feename,
                    feeamount = payment.feeamount,
                    totalamount = payment.totalamount,
                    discount = payment.discount,
                    finalamount = payment.finalamount,
                };
                var mydata = await objPayment.CreateAsync(paymentdata);

                var paymentDto = mapper.Map<PaymentDto>(mydata);

                if (paymentDto == null)
                {
                    status.StatusCode = 203;
                    status.Message = "Invoice no. is already exists.";
                }
                else if (paymentDto.id > 0)
                {
                    status.StatusCode = 201;
                    status.Message = "Data saved successfully.";
                }
                else
                {
                    status.StatusCode = 204;
                    status.Message = "No content found";
                }
            }

            return Ok(status);
        }
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var model = await objPayment.DeleteAsync(id);
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

            domainModel = await objPayment.UpdateAsync(id, domainModel);

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

        [HttpGet("getmaxinvoice")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> getmaxinvoiceno()
        {
            string sqlquery = "select distinct(ISNULL(max(invoiceno),0)) as invoiceno from TblPayments";

            var data = await imsContext.getmaxinvoiceno.FromSqlRaw(sqlquery).ToListAsync();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
