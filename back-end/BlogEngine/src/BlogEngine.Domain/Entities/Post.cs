using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.Domain.Entities;

public class Post
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateTime PublicationDate { get; set; }

    public string Content { get; set; } = string.Empty;

    public long CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
