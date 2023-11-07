namespace CG.API.Exceptions
{
    public class MapFromDomainException : Exception
    {
        public MapFromDomainException(string? message) : base(message)
        {
        }

        public MapFromDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
