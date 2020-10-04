namespace SeoulAir.Gateway.Domain.Resources
{
    public static class Strings
    {
        public const string ParameterNullOrEmptyMessage = "Parameter {0} must not be null or empty string.";
        public const string ParameterBetweenMessage = "Value of parameter {0} must be between {1} and {2}.";
        public const string InvalidParameterValueMessage = "Value of parameter {0} has invalid value.";
        public const string RequestBodyGetException = "Http method GET does not support request body.";

        public const string InternalServerErrorUri = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
        public const string NotImplementedUri = "https://tools.ietf.org/html/rfc7231#section-6.6.2";
        public const string ConflictUri = "https://tools.ietf.org/html/rfc7231#section-6.5.8";

        public const string InternalServerErrorTitle = "500 Internal Server Error";
        public const string NotImplementedTitle = "501 Not Implemented";
        public const string ConflictTitle = "409 Conflict";
    }
}
