namespace JWTAuthentication.Features.GetUserInfoById;

[Route("api/[controller]")]
[ApiController]
public class GetUserInfoByIdController : ControllerBase
{
    private readonly IRoleAuthorizationService _roleAuthorizationService;
    private readonly IGetUserInfoByIdService _service;

    public GetUserInfoByIdController(IRoleAuthorizationService roleAuthorizationService, IGetUserInfoByIdService service)
    {
        _roleAuthorizationService = roleAuthorizationService;
        _service = service;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUserInfoById([FromQuery] GetUserInfoByIdRequest req)
    {
        try
        {
            //Authorization
            var roleId = int.Parse(User!.FindFirst(ClaimTypes.Role)!.Value);
            var isAuthorize = await _roleAuthorizationService.IsAuthorized(
                roleId, 
                AuthConst.MODULE_NAME_USERACCOUNT, 
                AuthConst.ACTION_NAME_VIEW);
            if (!isAuthorize)
            {
                return Unauthorized();
            }

            var response = await _service.GetUserInfoById(req);
            return StatusCode(response.StatusCode, response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
