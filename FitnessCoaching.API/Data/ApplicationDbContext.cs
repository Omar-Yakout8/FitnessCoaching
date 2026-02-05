using FitnessCoaching.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessCoaching.API.Data;

public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}
}


/*This automatically includes:

Users

Roles

UserRoles

Claims

Tokens*/