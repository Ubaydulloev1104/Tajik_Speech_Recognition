﻿using Application.Contracts.Applications.Commands.Delete;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Applications.Command.DeleteApplication;

public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;

    public DeleteApplicationCommandHandler(IApplicationDbContext context, IDateTime dateTime, ICurrentUserService currentUserService)
    {
        _context = context;
        _dateTime = dateTime;
        _currentUserService = currentUserService;
    }

    public async Task<bool> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Applications.FirstOrDefaultAsync(t => t.Slug == request.Slug, cancellationToken)
            ?? throw new NotFoundException(nameof(Application), request.Slug);

        ApplicationTimelineEvent timelineEvent = new ApplicationTimelineEvent
        {
            ApplicationId = entity.Id,
            EventType = TimelineEventType.Deleted,
            Time = _dateTime.Now,
            Note = "Application deleted",
            CreateBy = _currentUserService.GetUserId() ?? Guid.Empty
        };

        _context.Applications.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
