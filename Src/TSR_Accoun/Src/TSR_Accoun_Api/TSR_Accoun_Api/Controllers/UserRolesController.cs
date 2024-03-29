﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSR_Accoun_Application.Contracts.UserRoles.Commands;
using TSR_Accoun_Application.Contracts.UserRoles.Queries;

namespace TSR_Accoun_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(ApplicationPolicies.Administrator)]
	public class UserRolesController : ControllerBase
	{
		private readonly IMediator _mediator;
		public UserRolesController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] GetUserRolesQuery query)
		{
			return Ok(await _mediator.Send(query));
		}

		[HttpGet("{slug}")]
		public async Task<IActionResult> Get(string slug)
		{
			var query = new GetUserRolesBySlugQuery { Slug = slug };
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateUserRolesCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpDelete("{slug}")]
		public async Task<IActionResult> Delete(string slug)
		{
			var command = new DeleteUserRoleCommand { Slug = slug };
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
