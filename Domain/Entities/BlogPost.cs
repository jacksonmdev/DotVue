using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class BlogPost : AuditableEntity
{
    public Guid PostId { get; set; }
    public required string Title { get; set; }
    public PostStatus Status { get; set; }
}