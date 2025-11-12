using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PilotSchoolCheckIn.Authentication;
using PilotSchoolCheckIn.Contexts;
using PilotSchoolCheckIn.Repositories;
using PilotSchoolCheckIn.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var config = builder.Configuration;

// Initialize Postgres connectivity
const string connectionSettingKey = "Postgres";
var connectionString = builder.Configuration.GetConnectionString(connectionSettingKey) ?? throw
	new Exception("Postgres connection string not found");
connectionString = Environment.GetEnvironmentVariable(connectionSettingKey) ?? connectionString;


// Register DbContext
builder.Services.AddDbContext<PostgresDbContext>(options =>
	options.UseNpgsql(connectionString));

builder.Services.AddControllers();

builder.Services.Configure<JwtOptions>(config.GetSection(nameof(JwtOptions)));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPlaneRepository, PlaneRepository>();
builder.Services.AddScoped<IPlaneService, PlaneService>();

builder.Services.AddScoped<IJwtAuthentication, JwtAuthentication>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"]!)),
		};

		options.Events = new JwtBearerEvents
		{
			OnMessageReceived = context =>
			{
				context.Token = context.Request.Cookies["jwtToken"];

				return Task.CompletedTask;
			}
		}; 
	});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
