namespace BlogEngine.Communication.requests;

public class RequestPosts
{
    public string Title { get; set; } = string.Empty;

    public DateTime PublicationDate { get; set; }

    public string Content { get; set; } = string.Empty;
}
