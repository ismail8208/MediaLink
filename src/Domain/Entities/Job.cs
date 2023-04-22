﻿namespace MediaLink.Domain.Entities;
public class Job : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int UserId { get; set; }
    public InnerUser? User { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Like>? Likes { get; set; }
    public List<Skill>? Skills { get; set; }
}
