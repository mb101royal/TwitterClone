using Microsoft.AspNetCore.Identity;
using System.Text;
using TwitterClone.Business.Exceptions.AppUser;
using TwitterClone.Business.Exceptions.Role;
using TwitterClone.Core.Entities;
using TwitterClone.Core;
using Microsoft.EntityFrameworkCore;

namespace TwitterClone.API.Helpers
{
    public static class Seed
    {
        public static IApplicationBuilder UseSeedData(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                using (var scope = context.RequestServices.CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    await CreateRolesAsync(roleManager);
                    await CreateUsersAsync(userManager, app);
                }
                await next();
            });

            return app;
        }

        static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.Roles.AnyAsync())
                foreach (var role in Enum.GetNames(typeof(Roles)))
                {
                    IdentityRole newRole = new(role);

                    IdentityResult roleCreationResult = await roleManager.CreateAsync(newRole);

                    if (!roleCreationResult.Succeeded)
                    {
                        StringBuilder sb = new();

                        foreach (var error in roleCreationResult.Errors)
                            sb.Append(error.Description + " ");

                        throw new RoleCreationFailedException(sb.ToString().TrimEnd());
                    }
                }
        }

        static async Task CreateUsersAsync(UserManager<AppUser> userManager, WebApplication app)
        {
            if (await userManager.FindByNameAsync(app.Configuration.GetSection("Admin")?["Username"]) == null)
            {
                AppUser user = new()
                {
                    UserName = app.Configuration.GetSection("Admin")["Username"],
                    Email = app.Configuration.GetSection("Admin")["Email"],
                    Fullname = app.Configuration.GetSection("Admin")["Fullname"],
                    EmailConfirmed = true
                };

                var userCreationResult = await userManager.CreateAsync(user, app.Configuration.GetSection("Admin")?["Password"]);

                if (!userCreationResult.Succeeded)
                {
                    StringBuilder sb = new();

                    foreach (var error in userCreationResult.Errors)
                        sb.Append(error.Description + " ");

                    throw new UserCreationFailedException(sb.ToString().TrimEnd());
                }

                var roleAssigningResult = await userManager.AddToRoleAsync(user, nameof(Roles.Admin));
            }
        }
    }
}
