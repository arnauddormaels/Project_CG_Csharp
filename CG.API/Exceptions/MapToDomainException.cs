namespace CG.API.Exceptions
{
    public class MapToDomainException : Exception
    {
        public MapToDomainException(string? message) : base(message)
        {
        }

        public MapToDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
