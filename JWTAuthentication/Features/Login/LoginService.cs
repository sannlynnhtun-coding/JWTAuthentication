namespace JWTAuthentication.Features.Login;

public interface ILoginService
{
    Task<LoginResponse> Login(LoginRequest req);
}

public class LoginService : ILoginService
{
    private readonly AuthContext _context;
    private readonly ITokenService _tokenService;

    public LoginService(AuthContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> Login(LoginRequest req)
    {
        try
        {
            var User = await _context.User.Where(x => x.IsActive == true && x.Email == req.Email).FirstOrDefaultAsync();
            if (User == null)
            {
                return new LoginResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Wrong Email"
                };
            }

            var isAuthorize = _tokenService.VerifyPasswordHash(req.Password, User.PasswordHash, User.PasswordSalt);
            if (!isAuthorize)
            {
                return new LoginResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Wrong Password"
                };
            }

            return new LoginResponse
            {
                UserId = User.Id,
                Token = _tokenService.CreateToken(User),
                Name = User.Name,
                Email = User.Email,
                StatusCode = StatusCodes.Status200OK,
                Message = "Success"
            };

        }
        catch (Exception e)
        {
            return new LoginResponse
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = e.Message
            };
        }
    }
}