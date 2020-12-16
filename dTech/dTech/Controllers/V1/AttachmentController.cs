using dTech.Common.DTOs;
using dTech.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dTech.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;
        public AttachmentController(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }
        [HttpPost("SaveFiles")]
        public async Task<ActionResult> AttachmentRequest([FromForm] AttachmentRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _attachmentService.SaveFiles(model));

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

    }
}
