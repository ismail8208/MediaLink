﻿namespace MediaLink.Domain.Entities;

public class Skill : BaseAuditableEntity
{
    public string? Title { get; set; }
    public List<Endorsement> Endorsements { get; set; } = new List<Endorsement>();
    public int UserId { get; set; }
    public InnerUser? User { get; set; }
}
