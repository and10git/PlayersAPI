using ApplicationLayer.UseCases.Interfaces.LoginInterfaces;
using Microsoft.AspNetCore.Mvc;
using PlayersAPI.DTO.LoginDTO;
namespace PlayersAPI.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    { 
        private readonly ILoginUC _loginUC;
        private readonly ICreateUserUC _createUserUC;

        public LoginController(ILoginUC loginUC, ICreateUserUC createUserUC)
        {
            _loginUC = loginUC;
            _createUserUC = createUserUC;
        }

        /// <summary>
        /// Get authorization token
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns>Token</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequestDTO loginDTO)
        {
            try
            {
                var userValid = _loginUC.Authenticate(loginDTO.User, loginDTO.Password);
                if (!userValid)
                {
                    return Unauthorized("Invalid credentials");
                }

                var token = _loginUC.GetToken(loginDTO.User, loginDTO.Password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest($"error: {ex.Message}");
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns>Status code</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(LoginRequestDTO loginDTO)
        {
            try
            {
                _createUserUC.CreateUser(loginDTO.User, loginDTO.Password);                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"error: {ex.Message}");
            }
        }
    }
}
       



