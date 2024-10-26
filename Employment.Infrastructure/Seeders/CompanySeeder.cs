using Employment.Application.Abstractions;
using Employment.Application.Shared.Specifications;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

internal class CompanySeeder : ISeeder
{
    private readonly IGenericRepository<Company> _companyRepo;
    private readonly ILogger<CompanySeeder> _logger;
    private readonly AppDbContext _dbContext;

    public CompanySeeder(IGenericRepository<Company> companyRepo, ILogger<CompanySeeder> logger, AppDbContext dbContext)
    {
        _companyRepo = companyRepo;
        _logger = logger;
        _dbContext = dbContext;
    }

    public int ExecutionOrder { get; set; } = 2;

    public async Task SeedAsync()
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Companies ON");

                var companies = new List<Company>
                {
                    new Company(1, "PaySky"),
                    new Company(2, "Microsoft"),
                    new Company(3, "Google")
                };

                foreach (var company in companies)
                {
                    var existingCompany = _companyRepo.GetEntityWithSpec(new GetCompanyByNameSpecification(company.Name));
                    if (existingCompany == null)
                    {
                        await _companyRepo.AddAsync(company);
                        _logger.LogInformation($"Seeded company: {company.Name}");
                    }
                    else
                    {
                        _logger.LogInformation($"Company {company.Name} already exists.");
                    }
                }

                await _companyRepo.SaveChangesAsync();

                await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Companies OFF");

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the Companies table.");
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
