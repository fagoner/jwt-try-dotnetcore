using JwtTry.Managers;
using JwtTry.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtTry.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    

    public class TokensController : ControllerBase
    {

        private IJWTAuthenticationManager _jWTAuthenticationManager;

        public TokensController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _jWTAuthenticationManager = jWTAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpGet("ping")]
        public ActionResult Hi()
        {
            return Ok(new { Message = "Pong" });
        }

        [HttpGet("hi")]
        public ActionResult HiProtected()
        {
            return Ok(new { Message = "Protected greet" });
        }

        [HttpPost("auth")]
        public ActionResult<string> Authenticate([FromBody] UserCred userCred)
        {
            var token = _jWTAuthenticationManager.Authenticate(userCred);

            if (token == null)
                return BadRequest(new { Message = "user/password is invalid" });

            return Ok(new { Token = token });
        }

    }

}