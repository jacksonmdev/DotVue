using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<BlogPost> BlogPosts { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
