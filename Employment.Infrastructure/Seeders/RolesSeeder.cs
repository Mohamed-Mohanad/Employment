using Employment.Application.Abstractions;
using Employment.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Employment.Infrastructure.Seeders
{
    public class RolesSeeder : ISeeder
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ILogger<RolesSeeder> _logger;

        public RolesSeeder(RoleManager<IdentityRole<Guid>> roleManager, ILogger<RolesSeeder> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }

        public int ExecutionOrder { get; set; } = 1;

        public async Task SeedAsync()
        {
            var roles = new List<string>()
            {
                Role.Employer.ToString(),
                Role.Applicant.ToString(),
            };

            var existingRoles = new HashSet<string>(await _roleManager.Roles.Select(x => x.Name).ToListAsync());

            var newRoles = roles
                .Where(r => !existingRoles.Contains(r))
                .ToList();

            if (!newRoles.Any())
            {
                _logger.LogInformation("No new roles to add.");
                return;
            }

            foreach (var newRole in newRoles)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole<Guid>(newRole));
                if (!result.Succeeded)
                {
                    _logger.LogError($"Failed to create role: {newRole}");
                    throw new Exception($"Failed to create role: {newRole}");
                }
            }

            _logger.LogInformation("Roles seeded successfully.");
        }
    }
}
