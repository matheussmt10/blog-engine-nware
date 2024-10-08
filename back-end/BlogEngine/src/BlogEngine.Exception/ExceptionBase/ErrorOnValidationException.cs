﻿namespace BlogEngine.Exception.ExceptionBase;

public class ErrorOnValidationException : BlogEngineException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        Errors = errorMessages;
    }
}
