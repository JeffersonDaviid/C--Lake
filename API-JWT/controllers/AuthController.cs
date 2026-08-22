using Microsoft.AspNetCore.Mvc;
using RestAPI.Models.Dto;

namespace RestAPI.Controllers;

[ApiController]
[Route("api/[controller]/login")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    // Inyectamos IConfiguration para poder leer appsettings.json
    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserDTO user)
    {
        // 1. Validaríamos contra la base de datos (Omitido para este ejemplo)
        if (user.Name == null) return Unauthorized();

        // 2. Empaquetamos los datos del DTO en Claims

        // 3. Encriptación
        var token = _config.GetValue<string>("Jwt:key");

        return Ok();
    }
}