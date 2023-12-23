namespace JWTAuthentication.Features.Login;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginService _service;

    public LoginController(ILoginService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest req)
    {
        try
        {
            var response = await _service.Login(req);
            return StatusCode(response.StatusCode, response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}