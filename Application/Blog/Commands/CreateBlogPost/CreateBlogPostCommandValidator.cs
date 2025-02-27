namespace Application.Blog.Commands.CreateBlogPost;

public class CreateBlogPostCommandValidator : AbstractValidator<CreateBlogPostCommand>
{
    public CreateBlogPostCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(v => $"${nameof(CreateBlogPostCommand.Title)} is required");

        RuleFor(v => v.Status)
            .NotNull()
            .NotEmpty()
            .WithMessage(v => $"{nameof(CreateBlogPostCommand.Status)} required");
    }
}
