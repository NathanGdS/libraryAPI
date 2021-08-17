using LibraryAPI.Business;
using LibraryAPI.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }
        
        [HttpPost]
        [Route("sigin")]

        public IActionResult Sigin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid Request!");
            TokenVO token = _loginBusiness.ValidateCredentials(user);
            if (token == null) return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]

        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO is null) return BadRequest("Invalid TokenVO!");
            TokenVO token = _loginBusiness.ValidateCredentials(tokenVO);
            if (token == null) return BadRequest("Invalid Token!");

            return Ok(token);
        } 
        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]

        public IActionResult Revoke()
        {

            string username = User.Identity.Name;
            bool result = _loginBusiness.RevokeToken(username);

            if (!result) return BadRequest("Invalid Token!");

            return NoContent();
        }

    }
}
