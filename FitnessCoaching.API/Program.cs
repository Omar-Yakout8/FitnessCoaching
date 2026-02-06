using FitnessCoaching.API.Data;
using FitnessCoaching.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection")
	));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequiredLength = 6;
	options.Password.RequireUppercase = false;
	options.Password.RequireNonAlphanumeric = false;
})
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed roles and admin user
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	await RoleSeeder.SeedRolesAsync(services);
	await AdminSeeder.SeedAdminAsync(services);
}

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
