using BlazorPunchCard.Data;
using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Data.Models.ViewModels;
using BlazorPunchCard.Repositories;
using BlazorPunchCard.Repositories.Interfaces;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace BlazorPunchCard.Tests.Repository;

public class DashBoardRepositoryTests
{
	private readonly IPunchRepository _punchRepository;

	public DashBoardRepositoryTests()
	{
		_punchRepository = A.Fake<IPunchRepository>();
	}

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
	public async void DashBoardRepository_GetCompanyById_ReturnsListOfTransactions() 
	{
		// Arrange
		var companyId = 11;
		var dbContext = await GetDbContext();
		var dashBoardRepository = new DashBoardRepository(dbContext, _punchRepository);

		// Act
		var result = await dashBoardRepository.GetByCompanyId(companyId);

		// Assert
		result.Should().BeOfType(typeof(List<DashBoardViewModel>));
		result.Should().HaveCount(3);
	}

	[Fact]
	public async void DashBoardRepository_GetNumberOfActivePunchCards_ReturnsNumberOfPunchCardsWhereIsActiveIsTrue()
	{
		// Arrange
		var companyId = 11;
		var dbContext = await GetDbContext();
		var dashBoardRepository = new DashBoardRepository(dbContext, _punchRepository);

		// Act
		var result = dashBoardRepository.GetNumberOfActivePunchCards(companyId);

		// Assert
		result.Should().NotBeNull();
		result.Result.Should().Be(2);
	}

	[Fact]
	public async void DashBoardRepository_GetTotalNumberOfPunchCards_ReturnsTotalNumberOfPunchCards()
	{
		// Arrange
		var companyId = 11;
		var dbContext = await GetDbContext();
		var dashBoardRepository = new DashBoardRepository(dbContext, _punchRepository);

		// Act
		var result = dashBoardRepository.GetTotalNumberOfPunchCards(companyId);

		// Assert
		result.Should().NotBeNull();
		result.Result.Should().Be(3);
	}

	[Fact]
	public async void DashBoardRepository_GetNumberOfRewardsGiven_ReturnsNumberOfRewardsGiven()
	{
		// Arrange
		var companyId = 11;
		var dbContext = await GetDbContext();
		var dashBoardRepository = new DashBoardRepository(dbContext, _punchRepository);

		// Act
		var result = dashBoardRepository.GetNumberOfRewardsGiven(companyId);

		// Assert
		result.Should().NotBeNull();
		result.Result.Should().Be(2);
	}

	[Fact]
	public async void DashBoardRepository_GetNumberOfRewardsRedeemed_ReturnsNumberOfRewardsRedeemed()
	{
		// Arrange
		var companyId = 11;
		var dbContext = await GetDbContext();
		var dashBoardRepository = new DashBoardRepository(dbContext, _punchRepository);

		// Act
		var result = dashBoardRepository.GetNumberOfRewardsRedeemed(companyId);

		// Assert
		result.Should().NotBeNull();
		result.Result.Should().Be(1);
	}
}
