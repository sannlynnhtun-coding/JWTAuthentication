namespace JWTAuthentication.Features.GetUserInfoById;

public interface IGetUserInfoByIdService
{
    Task<GetUserInfoByIdResponse> GetUserInfoById(GetUserInfoByIdRequest req);
}

public class GetUserInfoByIdService : IGetUserInfoByIdService
{
    private readonly AuthContext _context;
    private readonly IConfiguration _configuration;

    public GetUserInfoByIdService(AuthContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<GetUserInfoByIdResponse> GetUserInfoById(GetUserInfoByIdRequest req)
    {
        try
        {
            var user = await _context.User.Where(x => x.IsActive == true && x.Id == req.Id).FirstOrDefaultAsync();
            if (user == null)
            {
                return new GetUserInfoByIdResponse
                {
                    StatusCode = StatusCodes.Status204NoContent,
                    Message = "No User Found"
                };
            }

            return new GetUserInfoByIdResponse
            {
                Id = user.Id,
                UserName = user.Name,
                Email = user.Email,
                StatusCode = StatusCodes.Status200OK,
                Message = "Success"
            };
        }
        catch (Exception e)
        {
            return new GetUserInfoByIdResponse
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = e.Message
            };
        }
    }
}