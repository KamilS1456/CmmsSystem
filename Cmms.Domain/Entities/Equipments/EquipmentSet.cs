

using Cmms.Domain.Entities.Quest;
using Cmms.Domain.Exceptions;
using Cmms.Domain.Validators.EquipmentSetValidators;
using Cmms.Domain.Validators.QuestValidators;
using FluentValidation;
using static Cmms.Domain.Dictionary.QuestStateEnum;

namespace Cmms.Domain.Entities.Equipments
{
    public class EquipmentSet : EntityBase 
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual List<EquipmentSetToEquipment> EquipmentSetToEquipments { get; private set; }



        // Factory method
        public static EquipmentSet CreateEquipmentSet(Guid userProfileID, string name, string description, IEnumerable<EquipmentSetToEquipment> equipmentSetToEquipments)
        {
            var validator = new EquipmentSetValidator();
            var equipmentSet = new EquipmentSet
            {
                LastModifyByUserId = userProfileID,
                CreatedByUserId = userProfileID,
                CreationDateTime = DateTime.UtcNow,
                LastModifyDateTime = DateTime.UtcNow,
                Name = name,
                Description = description,
            };
            equipmentSet.UpdatedEquipmentSetToEquipmentList(equipmentSetToEquipments);

            var validationResult = validator.Validate(equipmentSet);

            if (validationResult.IsValid)
            {
                return equipmentSet;
            }

            var exception = new EquipmentSetNotValidException("The equipmentSet is not valid");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            throw exception;

        }

        //public methods

        public void UpdateEquipmentSet(Guid userProfileID, string name, string description, IEnumerable<EquipmentSetToEquipment> equipmentSetToEquipments)
        {
            LastModifyByUserId = userProfileID;
            LastModifyDateTime = DateTime.UtcNow;
            Name = name;
            Description = description;

            UpdatedEquipmentSetToEquipmentList(equipmentSetToEquipments);

            var validator = new EquipmentSetValidator();
            var validationResult = validator.Validate(this);

            if (!validationResult.IsValid)
            {
                var exception = new EquipmentSetNotValidException("The equipmentSet is not valid");
                foreach (var error in validationResult.Errors)
                {
                    exception.ValidationErrors.Add(error.ErrorMessage);
                }
                throw exception;
            }


        }

        void UpdatedEquipmentSetToEquipmentList(IEnumerable<EquipmentSetToEquipment> equipmentSetToEquipment)
        {
            var updatedEquipmentSetToEquipmentList = new List<EquipmentSetToEquipment>();
            foreach (var este in equipmentSetToEquipment)
            {
                updatedEquipmentSetToEquipmentList.Add(EquipmentSetToEquipment.CreateEquipmentSetToEquipment(Id, este.EquipmentID));
            }
            EquipmentSetToEquipments = updatedEquipmentSetToEquipmentList;
        }
    }
}
