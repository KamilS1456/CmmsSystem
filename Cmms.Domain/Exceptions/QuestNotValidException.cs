namespace Cmms.Domain.Exceptions
{

    public class QuestNotValidException : DomainModelInvalidException
    {
        internal QuestNotValidException() { }
        internal QuestNotValidException(string message) : base(message) { }
        internal QuestNotValidException(string message, Exception inner) : base(message, inner) { }
    }
}