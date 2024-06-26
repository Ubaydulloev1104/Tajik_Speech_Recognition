﻿using Application.Contracts.Applications.Queries.GetApplicationBySlug;
using Application.Contracts.Applications.Responses;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Applications.Query.GetApplicationBySlug
{
    public class GetApplicationBySlugQueryHandler : IRequestHandler<GetBySlugApplicationQuery, ApplicationDetailsDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetApplicationBySlugQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationDetailsDto> Handle(GetBySlugApplicationQuery request, CancellationToken cancellationToken)
        {
            var application = await _dbContext.Applications
                  .Include(a => a.History)
                  .FirstOrDefaultAsync(a => a.Slug == request.Slug, cancellationToken);
            _ = application ?? throw new NotFoundException(nameof(Application), request.Slug);

            return _mapper.Map<ApplicationDetailsDto>(application);
        }
    }
}
