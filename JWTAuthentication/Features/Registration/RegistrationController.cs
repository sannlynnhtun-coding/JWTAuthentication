namespace JWTAuthentication.Features.Registration;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly IRegistrationService _services;

    public RegistrationController(IRegistrationService services)
    {
        _services = services;
    }

    [HttpPost]
    public async Task<IActionResult> Registration(RegistrationRequest req)
    {
        try
        {
            var response = await _services.Registration(req);
            return StatusCode(response.StatusCode, response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}