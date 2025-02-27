using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;

namespace Application.Blog.Commands.CreateBlogPost;

public class CreateBlogPostCommand : IRequest<int>
{
    public required string Title { get; set; }
    public PostStatus Status { get; set; }
}

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBlogPostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var entity = new BlogPost { Title = request.Title, Status = request.Status };
        _context.BlogPosts.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
