namespace BlogEngine.Exception.ExceptionBase;

public abstract class BlogEngineException : SystemException
{
    protected BlogEngineException(string message) : base(message)
    {
        
    }
}
