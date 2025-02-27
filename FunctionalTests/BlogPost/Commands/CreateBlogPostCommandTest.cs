using Application.Blog.Commands.CreateBlogPost;
using Domain.Enums;
using FunctionalTests.Common;

namespace FunctionalTests.BlogPost.Commands;

using static Testing;

public class CreateBlogPostCommandTest : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateBlogPost()
    {
        await RunAsDefaultUserAsync();
        var command = new CreateBlogPostCommand { Title = "Where is John Doe?", Status = PostStatus.Draft };
        
        var result = await SendAsync(command);
        result.Should().Be(1);

    }
}
