using Microsoft.EntityFrameworkCore;
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


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
