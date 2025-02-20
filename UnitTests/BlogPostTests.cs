using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests;

public class BlogPostTests
{
    [Test]
    public void ShouldAppendBlogPost() 
    {
        var blogPosts = new List<BlogPost>();
        var blog = new BlogPost
        {
            Title = "Hello, Jane Doe",
            PostId = new Guid(),
            Status = Domain.Enums.PostStatus.Published
        };

        blogPosts.Add(blog);

        blogPosts.Count.Should().BeGreaterThan(5);
    }
}
