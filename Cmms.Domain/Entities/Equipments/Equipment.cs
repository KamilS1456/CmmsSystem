using Cmms.Domain.Entities.Quest;
using Cmms.Domain.Exceptions;
using Cmms.Domain.Validators.EquipmentValidators;
using static Cmms.Domain.Dictionary.EquipmentConditionEnum;

namespace Cmms.Domain.Entities.Equipments
{
    public class Equipment : EntityBase
    {
        public string Name { get; private set; }
        public string Model { get; private set; }
        public string SN { get; private set; }
        public EquipmentCondition Condition { get; private set; }
        public DateTime LastServiceDateTime { get; private set; }


        // Factory method
        public static Equipment CreateEquipment(Guid userProfileID, string name, string model, string sn, EquipmentCondition equipmentCondition, DateTime lastServiceDateTime)
        {
            var validator = new EquipmentValidator();
            var quest = new Equipment
            {
                LastModifyByUserId = userProfileID,
                CreatedByUserId = userProfileID,
                CreationDateTime = DateTime.UtcNow,
                LastModifyDateTime = DateTime.UtcNow,
                Name = name,
                Model = model,
                SN = sn,
                Condition = equipmentCondition,
                LastServiceDateTime = lastServiceDateTime,
            };

            var validationResult = validator.Validate(quest);

            if (validationResult.IsValid)
            {
                return quest;
            }

            var exception = new EquipmentNotValidException("The quest is not valid");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            throw exception;

        }

        //public methods

        public void UpdateEquipment(Guid userProfileID, string name, string model, string sn, EquipmentCondition equipmentCondition, DateTime lastServiceDateTime)
        {
            LastModifyByUserId = userProfileID;
            LastModifyDateTime = DateTime.UtcNow;
            Name = name;
            Model = model;
            SN = sn;
            Condition = equipmentCondition;
            LastServiceDateTime = lastServiceDateTime;

            var validator = new EquipmentValidator();
            var validationResult = validator.Validate(this);

            if (!validationResult.IsValid)
            {
                var exception = new EquipmentNotValidException("The equipment is not valid");
                foreach (var error in validationResult.Errors)
                {
                    exception.ValidationErrors.Add(error.ErrorMessage);
                }
                throw exception;
            }
        }

    }
}
