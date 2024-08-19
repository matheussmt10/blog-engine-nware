namespace BlogEngine.Communication.Responses.Post;

public class ResponsePost
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateTime PublicationDate { get; set; }

    public string Content { get; set; } = string.Empty;

    public long CategoryId { get; set; }
}
