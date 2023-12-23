using System.Net.Http.Headers;

namespace JWTAuthentication.Services;

public class SwaggerAuthMiddlewareService
{
    private readonly RequestDelegate _next;

    public SwaggerAuthMiddlewareService(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                // Get credentials from request header
                var header = AuthenticationHeaderValue.Parse(authHeader);
                var inBytes = Convert.FromBase64String(header.Parameter!);
                var credentials = Encoding.UTF8.GetString(inBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                // validate credentials
                var isValid = username == "user@gmail.com" && password == "111111";

                if (isValid)
                {
                    await _next.Invoke(context).ConfigureAwait(false);
                    return;
                }
            }
            context.Response.Headers["WWW-Authenticate"] = "Basic";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
        else
        {
            await _next.Invoke(context).ConfigureAwait(false);
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class SwaggerAuthMiddlewareExtensions
{
    public static IApplicationBuilder UseSwaggerAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SwaggerAuthMiddlewareService>();
    }
}