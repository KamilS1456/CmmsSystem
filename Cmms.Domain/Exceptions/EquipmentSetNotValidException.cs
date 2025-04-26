namespace Cmms.Domain.Exceptions
{

    public class EquipmentSetNotValidException : DomainModelInvalidException
    {
        internal EquipmentSetNotValidException() { }
        internal EquipmentSetNotValidException(string message) : base(message) { }
        internal EquipmentSetNotValidException(string message, Exception inner) : base(message, inner) { }
    }
}