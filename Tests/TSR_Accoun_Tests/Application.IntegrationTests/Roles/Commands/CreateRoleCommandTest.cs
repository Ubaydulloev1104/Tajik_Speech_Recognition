﻿using System.Net.Http.Json;
using System.Net;
using TSR_Accoun_Application.Contracts.ApplicationRoles.Commands;
using TSR_Accoun_Domain.Entities;
using FluentAssertions;

namespace Application.IntegrationTests.Roles.Commands
{
	public class CreateRoleCommandTest : BaseTest
	{
		[Test]
		public async Task CreateRoleCommand_ShouldCreateRoleCommand_Success()
		{
			var command = new CreateRoleCommand
			{
				RoleName = "Test",
			};

			await AddAuthorizationAsync();
			var response = await _client.PostAsJsonAsync("/api/roles", command);

			response.EnsureSuccessStatusCode();
		}

		[Test]
		public async Task CreateRoleCommand_ShouldCreateRoleCommand_Failed()
		{
			var role = new ApplicationRole
			{
				Name = "test2",
				Slug = "test2",
				NormalizedName = "TEST2"
			};

			await AddEntity(role);


			var command = new CreateRoleCommand
			{
				RoleName = "test2",
			};

			await AddAuthorizationAsync();
			var response = await _client.PostAsJsonAsync("/api/roles", command);

			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}
	}

}
