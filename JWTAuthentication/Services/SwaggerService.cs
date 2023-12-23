namespace JWTAuthentication.Services;

public static class SwaggerService
{
    public static void AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1", Description = "Swagger for Auth system authorized by ZinKo" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                //Type = SecuritySchemeType.ApiKey,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
            });
        });
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    //                builder.Configuration.GetSection("AppSettings:SecrectKey").Value)),
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                        AuthConst.TOKEN_SECRECT)),
                    ValidateIssuer = true,
                    //ValidIssuer = builder.Configuration.GetSection("AppSettings:Issuer").Value,
                    ValidIssuer = AuthConst.TOKEN_ISSUER,
                    ValidateAudience = false,
                };
            });
    }
}