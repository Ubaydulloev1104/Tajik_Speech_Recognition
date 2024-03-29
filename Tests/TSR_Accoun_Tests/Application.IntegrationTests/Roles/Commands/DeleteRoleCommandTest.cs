﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TSR_Accoun_Domain.Entities;

namespace Application.IntegrationTests.Roles.Commands
{
	public class DeleteRoleCommandTest : BaseTest
	{
		[Test]
		public async Task DeleteRoleCommand_ShouldDeleteRoleCommand_Success()
		{
			var role = new ApplicationRole
			{
				Name = "Test5",
				Slug = "test5"
			};
			await AddEntity(role);

			await AddAuthorizationAsync();
			var response = await _client.DeleteAsync($"/api/roles/{role.Slug}");

			response.EnsureSuccessStatusCode();
		}

		[Test]
		public async Task DeleteRoleCommand_ShouldDeleteRoleCommand_NotFound()
		{

			await AddAuthorizationAsync();
			var response = await _client.DeleteAsync($"/api/roles/test7");

			Assert.That(response.StatusCode == HttpStatusCode.NotFound);
		}
	}
}
