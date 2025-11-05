using CleanCodeApp.Application.Services;
using CleanCodeApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(UserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _service.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consultando los usuarios");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            try
            {
                var user = await _service.GetByIdAsync(userId);
                return user is null ? NotFound() : Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consultando usuario con id: {userId}", userId);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> CreateNewUser(User user)
        {
            try
            {
                await _service.AddAsync(user);
                return CreatedAtAction(nameof(GetById), new { userId = user.Id }, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creando un nuevo usuario");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> Update(User user)
        {
            try
            {
                await _service.UpdateAsync(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error actualizando el usuario con id: {userId}", user.Id);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                await _service.DeleteAsync(userId);
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando el usuario con id: {userId}", userId);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
