﻿namespace Application.Contracts.Applications.Commands.CreateApplication
{
	public class CreateApplicationWithoutApplicantIdCommand : IRequest<Guid>
	{
		public Guid WordId { get; set; }
	}
}
