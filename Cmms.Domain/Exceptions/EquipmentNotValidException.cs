namespace Cmms.Domain.Exceptions
{

    public class EquipmentNotValidException : DomainModelInvalidException
    {
        internal EquipmentNotValidException() { }
        internal EquipmentNotValidException(string message) : base(message) { }
        internal EquipmentNotValidException(string message, Exception inner) : base(message, inner) { }
    }
}