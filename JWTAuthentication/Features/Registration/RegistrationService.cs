namespace JWTAuthentication.Features.Registration;

public interface IRegistrationService
{
    Task<RegistrationResponse> Registration(RegistrationRequest request);
}

public class RegistrationService : IRegistrationService
{
    private readonly AuthContext _context;
    private readonly ITokenService _tokenService;

    public RegistrationService(AuthContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<RegistrationResponse> Registration(RegistrationRequest request)
    {
        try
        {
            //User Validation
            var user = await _context.User.AnyAsync(x => x.IsActive == true && x.Email == request.Email);

            if (user == true)
            {
                return new RegistrationResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Email has already Registered"
                };
            }

            _tokenService.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

            var userToAdd = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = Guid.NewGuid(), //Temporary
                IsActive = true
            };
            await _context.User.AddAsync(userToAdd);
            await _context.SaveChangesAsync();

            userToAdd.CreatedBy = userToAdd.Id;
            await _context.SaveChangesAsync();

            var token = _tokenService.CreateToken(userToAdd);

            return new RegistrationResponse
            {
                UserId = userToAdd.Id,
                Token = token,
                StatusCode = StatusCodes.Status200OK,
                Message = "Success"
            };
        }
        catch (Exception ex)
        {
            return new RegistrationResponse
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = ex.Message
            };
        }
    }
}