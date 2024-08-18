namespace BlogEngine.Communication.Requests.Post;

public class RequestCreatePost
{
    public string Title { get; set; } = string.Empty;

    public DateTime PublicationDate { get; set; }

    public string Content { get; set; } = string.Empty;

    public long CategoryId { get; set; }
}
