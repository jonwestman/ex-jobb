using BlazorPunchCard.Controller;
using BlazorPunchCard.Data.Models.ViewModels;
using BlazorPunchCard.Repositories.Interfaces;
using FakeItEasy;
using FluentAssertions;

namespace BlazorPunchCard.Tests.Controller;

public class DashBoardControllerTests
{
	private readonly IDashBoardRepository _dashboardRepository;

	public DashBoardControllerTests()
	{
		_dashboardRepository = A.Fake<IDashBoardRepository>();
	}

	[Fact]
	public void DashBoardController_PopulateDashboard_ReturnTransactions()
	{
		// Arrange
		var companyId = 11;
		var controller = new DashBoardController(_dashboardRepository);

		// Act
		var result = controller.PopulateDashboard(companyId);

		// Assert
		result.Should().NotBeNull();
		result.Should().BeOfType(typeof(Task<List<DashBoardViewModel>>));
	}
}
