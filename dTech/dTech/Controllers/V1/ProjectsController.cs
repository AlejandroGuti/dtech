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
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] ProjectRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _projectService.Create(model));

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

                return Ok(await _projectService.FindAll());
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
                return Ok(await _projectService.FindById(request.Id));

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
                return Ok(await _projectService.Delete(request.Id));

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
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ProjectRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id > 0)
                {
                    return Ok(await _projectService.Update(id, request));
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
