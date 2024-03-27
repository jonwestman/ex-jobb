using BlazorPunchCard.Data;
using BlazorPunchCard.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPunchCard.Tests.Repository
{
	public class ApplicationUserRepositoryTests
	{
		private async Task<ApplicationDbContext> GetDatabaseContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
					.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
					.Options;
			var databaseContext = new ApplicationDbContext(options);
			databaseContext.Database.EnsureCreated();
			if (await databaseContext.ApplicationUsers.CountAsync() <= 0)
			{
				for (int i = 0; i < 10; i++)
				{
					databaseContext.ApplicationUsers.Add(
						new ApplicationUser()
						{
							Id = "1",
							Name = "Jon Westman",
							UserName = "jonwestman@hotmail.com",
							NormalizedUserName = "JONWESTMAN@HOTMAIL.COM",
							Email = "jonwestman@hotmail.com",
							NormalizedEmail = "JONWESTMAN@HOTMAIL.COM",
							EmailConfirmed = true,
							PhoneNumber = "0701234567"
						});
					await databaseContext.SaveChangesAsync();
				}
			}
			return databaseContext;
		}

		[Fact]
		public async void ApplicationUserRepository_GetById_ReturnsUser() 
		{
			// Arrange
			var userId = "1";
			var dbContext = await GetDatabaseContext();
			var applicationUserRepository = new ApplicationUserRepository(dbContext);

			// Act
			var result = applicationUserRepository.GetById(userId);	

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(Task<ApplicationUser>));
			result.IsCompleted.Should().BeTrue();
		}
		[Fact]
		public async void ApplicationUserRepository_GetByPhoneNumber_ReturnsUser() 
		{
			// Arrange
			var phoneNumber = "0701234567";
			var dbContext = await GetDatabaseContext();
			var applicationUserRepository = new ApplicationUserRepository(dbContext);

			// Act
			var result = applicationUserRepository.GetByPhoneNumber(phoneNumber);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeOfType<Task<ApplicationUser>>();
		}
	}
}
