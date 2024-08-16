namespace BlogEngine.Communication.requests;

public class RequestCreatePost
{
    public string Title { get; set; } = string.Empty;

    public DateTime PublicationDate { get; set; }

    public string Content { get; set; } = string.Empty;
}
