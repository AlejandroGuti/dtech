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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] CommentRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _commentService.Create(model));

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet()]
        public async Task<ActionResult> FindCommentList()
        {


            try
            {

                return Ok(await _commentService.FindAll());
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
                return Ok(await _commentService.FindById(request.Id));

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet("AllPTaks")]
        public async Task<ActionResult> FindAllPProject([FromBody] RequestId requestId)
        {
            try
            {

                return Ok(await _commentService.FindAllPTask(requestId));
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
                return Ok(await _commentService.Delete(request.Id));

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
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CommentRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id > 0)
                {
                    return Ok(await _commentService.Update(id, request));
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
