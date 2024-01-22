﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSR_Accoun_Application.Contracts.User.Queries;
using TSR_Accoun_Infrastructure.Identity;

namespace TSR_Accoun_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(ApplicationPolicies.Administrator)]
	public class UserController : ControllerBase
	{
		private readonly ISender _mediator;

		public UserController(ISender mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var users = await _mediator.Send(new GetAllUsersQuery());
			return Ok(users);
		}
		[HttpGet("{userName}")]
		public async Task<IActionResult> Get(string userName)
		{
			var query = new GetUserByUsernameQuery { UserName = userName };
			var user = await _mediator.Send(query);
			return Ok(user);
		}

		[HttpGet("CheckUserName/{userName}")]
		[AllowAnonymous]
		public async Task<IActionResult> CheckUserName([FromRoute] string userName)
		{
			var result = await _mediator.Send(new CheckUserNameQuery() { UserName = userName });
			return Ok(result);
		}
	}
}