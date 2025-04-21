namespace Cmms.Domain.Exceptions
{

    public class QuestTypeNotValidException : DomainModelInvalidException
    {
        internal QuestTypeNotValidException() { }
        internal QuestTypeNotValidException(string message) : base(message) { }
        internal QuestTypeNotValidException(string message, Exception inner) : base(message, inner) { }
    }
}