namespace Domain.Common;

public abstract class AuditableEntity
{
    public int Id { get; set; }   
    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}