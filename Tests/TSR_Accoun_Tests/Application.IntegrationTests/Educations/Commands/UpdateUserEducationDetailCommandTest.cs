﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Net;
using TSR_Accoun_Application.Contracts.Educations.Command.Update;
using TSR_Accoun_Domain.Entities;

namespace Application.IntegrationTests.Educations.Commands
{
	public class UpdateUserEducationDetailCommandTest : BaseTest
	{
		[Test]
		public async Task UpdateUserEductionDetailCommand_ShouldUpdateUserEductionDetailCommand_Success()
		{
			await AddApplicantAuthorizationAsync();

			var education = new EducationDetail()
			{
				Speciality = "test",
				University = "test",
				StartDate = DateTime.Now.AddYears(-5),
				EndDate = DateTime.Now.AddYears(-1),
				UntilNow = false,
				UserId = Applicant.Id,
			};

			await AddEntity(education);

			var command = new UpdateEducationDetailCommand()
			{
				Id = education.Id,
				Speciality = "test3",
				University = "test3",
				StartDate = education.StartDate,
				EndDate = education.EndDate,
				UntilNow = education.UntilNow,
			};

			var response2 = await _client.PutAsJsonAsync("/api/Profile/UpdateEducationDetail", command);

			response2.EnsureSuccessStatusCode();
		}

		[Test]
		public async Task UpdateUserEducationDetailCommand_ShouldFail_WhenDuplicateExists()
		{
			await AddApplicantAuthorizationAsync();

			var education1 = new EducationDetail()
			{
				Speciality = "test",
				University = "test",
				StartDate = DateTime.Now.AddYears(-5),
				EndDate = DateTime.Now.AddYears(-1),
				UntilNow = false,
				UserId = Applicant.Id,
			};

			var education2 = new EducationDetail()
			{
				Speciality = "test2",
				University = "test2",
				StartDate = DateTime.Now.AddYears(-5),
				EndDate = DateTime.Now.AddYears(-1),
				UntilNow = false,
				UserId = Applicant.Id,
			};

			await AddEntity(education1);
			await AddEntity(education2);

			var command = new UpdateEducationDetailCommand()
			{
				Id = education1.Id,
				Speciality = education2.Speciality,
				University = education2.University,
				StartDate = education1.StartDate,
				EndDate = education1.EndDate,
				UntilNow = education1.UntilNow,
			};

			var response = await _client.PutAsJsonAsync("/api/Profile/UpdateEducationDetail", command);

			Assert.That(HttpStatusCode.BadRequest==response.StatusCode);
			Assert.That((await response.Content.ReadFromJsonAsync<ProblemDetails>()).Detail.Contains("Education detail already exists"),Is.Not.False);
		}
	}
}
