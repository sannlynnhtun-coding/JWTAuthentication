var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Load Config Data 
AuthConst.LoadConfigData();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerService();

//builder.Services.AddDbContext<AuthContext>(options =>
//                            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AuthContext>(options =>
                              options.UseSqlServer(AuthConst.DB_CONNECTION));

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IRoleAuthorizationService, RoleAuthenticationService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IGetUserInfoByIdService, GetUserInfoByIdService>();

var app = builder.Build();

//Swagger Login
app.UseSwaggerAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
