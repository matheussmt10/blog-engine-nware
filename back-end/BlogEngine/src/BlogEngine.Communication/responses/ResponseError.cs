﻿namespace BlogEngine.Communication.responses
{
    public class ResponseError
    {
        public List<string> ErrorMessages { get; set; }

        public ResponseError(string errorMessage)
        {
            ErrorMessages = [errorMessage] ;
        }

        public ResponseError(List<string> errorMessage)
        {
            ErrorMessages = errorMessage;
        }
    }
}
