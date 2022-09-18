using CityEventsAPI.Application.DTO;
using CityEventsAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CityEventsAPI.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> CreateTokenAsync([FromForm] UserDTO userDTO)
        {
            var result =  await _userService.GenerateTokenAsync(userDTO);
            if (result.IsSucess)
                return Ok(result.Data);

            return BadRequest(result);

            /*
             Parâmetros para testes
             email: luganthierry@gmail.com, senha: 010203
             */
        }
    }
}
