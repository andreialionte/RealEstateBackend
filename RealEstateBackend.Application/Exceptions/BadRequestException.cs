namespace RealEstateBackend.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public int StatusCode { get; private set; }

        public BadRequestException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public BadRequestException(string message, int statusCode, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public override string ToString()
        {
            return $"BadRequestException: {Message}. Status Code: {StatusCode}.";
        }
    }
}