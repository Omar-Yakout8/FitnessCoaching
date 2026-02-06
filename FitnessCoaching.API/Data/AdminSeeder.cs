using FitnessCoaching.API.Models;
using Microsoft.AspNetCore.Identity;

namespace FitnessCoaching.API.Data;

public class AdminSeeder
{
	public static async Task SeedAdminAsync(IServiceProvider serviceProvider)
	{
		var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

		string adminEmail = "admin@fitness.com";
		string adminPassword = "Admin@123";

		var adminUser = await userManager.FindByEmailAsync(adminEmail);

		if (adminUser == null)
		{
			adminUser = new ApplicationUser
			{
				UserName = adminEmail,
				Email = adminEmail,
				EmailConfirmed = true
			};

			var result = await userManager.CreateAsync(adminUser, adminPassword);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(adminUser, "Admin");
			}

		}
	}
}
