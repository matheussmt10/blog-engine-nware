namespace BlogEngine.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateTime PublicationDate { get; set; }

    public string Content { get; set; } = string.Empty;
}
