using BlazorPunchCard.Data;
using BlazorPunchCard.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorPunchCard.Tests.Repository;

public class CompanyRepositoryTests
{
	private async Task<ApplicationDbContext> GetDbContext()
	{
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
			.Options;
		var databaseContext = new ApplicationDbContext(options);
		databaseContext.Database.EnsureCreated();
	
		return databaseContext;
	}

	[Fact]
	public async void CompanyRepository_GetCompanyByUserId_ReturnsUser()
	{
		// Arrange
		var userId = "11";
		var dbContext = await GetDbContext();
		var companyRepository = new CompanyRepository(dbContext);

		// Act
		var result = await companyRepository.GetCompanyByUserId(userId);

		// Assert
		result.Should().NotBeNull();
		result.Should().BeOfType<Task<Company>>();
		result.CompanyName.Should().Be("BokHörnan");
		result.CompanyId.Should().Be(11);
	}
}
