
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
    //[EnableCors("NewShore")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(
             IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _accountService.CreateUser(request));

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] TokenRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _accountService.Login(request));

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
