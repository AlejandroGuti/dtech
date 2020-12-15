using dTech.Common.DTOs;
using dTech.Common.Responses;
using dTech.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace dTech.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PTaskController : ControllerBase
    {

        private readonly IPTaskService _pTaskService;

        public PTaskController(IPTaskService pTaskService)
        {
            _pTaskService = pTaskService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] PTaskRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _pTaskService.Create(model));

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet()]
        public async Task<ActionResult> FindInvoiceList()
        {


            try
            {

                return Ok(await _pTaskService.FindAll());
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet("FindById")]
        public async Task<ActionResult> FindById([FromBody] RequestId request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _pTaskService.FindById(request.Id));

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromBody] RequestId request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _pTaskService.Delete(request.Id));

            }
            catch (Exception ex)
            {

                return BadRequest(new Response
                {
                    IsSuccess = true,
                    Message = ex.Message

                });
            }

        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] PTaskRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id > 0)
                {
                    return Ok(await _pTaskService.Update(id, request));
                }
                else
                {
                    return BadRequest();
                }




            }
            catch (Exception ex)
            {
                Exception j = ex;
                return BadRequest();
            }

        }

    }
}
