﻿namespace Domain.Entities;

public class Application : BaseAuditableEntity
{
    public string Slug { get; set; }
    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
    public ApplicationStatus Status { get; set; }
    public string ApplicantUsername { get; set; }
    public Guid ApplicantId { get; set; }
    public ICollection<ApplicationTimelineEvent> History { get; set; }
    public Words Words { get; set; }
    public Guid WordId { get; set; }
    public IEnumerable<Audio> Audios { get; set; }
    public string commit { get; set; }

}
