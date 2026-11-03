using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HurtowniaAPI.Entities
{
    public static class DataSeeder
    {
        public static async Task<WebApplication> SeedDataAsync(this WebApplication webApp)
        {
            using var scope = webApp.Services.CreateScope();
            var admin = new Użytkownik() { UserName = "Admin", Email = "admin@hurtownia.com", Imię = "Admin", Nazwisko = "Admin" };
            var hasło = "Admin12#";
            IdentityResult? result = null;
            IdentityResult? result2 = null;
            IdentityResult? result3 = null;
            List<string> role = new() { "Admin", "Klient", "Pracownik" };
            using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!await roleManager.RoleExistsAsync(role[0]))
            {
                result = await roleManager.CreateAsync(new IdentityRole(role[0]));
            }
            using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Użytkownik>>();
            if (await userManager.FindByNameAsync("Admin") == null)
            {
                result2 = await userManager.CreateAsync(admin, hasło);
            }
            if (result != null && result2 != null)
            {
                if (result.Succeeded && result2.Succeeded)
                {
                    if (!await userManager.IsInRoleAsync(admin, role[0]))
                    {
                        result3 = await userManager.AddToRoleAsync(admin, role[0]);
                    }
                    if (result3 != null)
                    {
                        if (result3.Succeeded)
                        {
                            var test = await userManager.GetClaimsAsync(admin);
                            if (test.Count == 0) 
                            {
                                var użytkownik = await userManager.FindByNameAsync(admin.UserName);
                                var result4 = await userManager.AddClaimsAsync(admin, new List<Claim>()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, użytkownik.Id),
                                    new Claim(ClaimTypes.Name, admin.UserName),
                                    new Claim(ClaimTypes.Role, role[0])
                                });
                            }
                        }
                    }
                }
            }
            if (!await roleManager.RoleExistsAsync(role[1]))
            {
                var result5 = await roleManager.CreateAsync(new IdentityRole(role[1]));
            }
            if (!await roleManager.RoleExistsAsync(role[2]))
            {
                var result6 = await roleManager.CreateAsync(new IdentityRole(role[2]));
            }
            return webApp;
        }

    }
}
