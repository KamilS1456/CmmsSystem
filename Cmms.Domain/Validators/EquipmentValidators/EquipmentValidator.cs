using Cmms.Domain.Entities.Equipments;
using Cmms.Domain.Entities.Quest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Domain.Validators.EquipmentValidators
{
    public class EquipmentValidator : AbstractValidator<Equipment>
    {
        public EquipmentValidator()
        {
            RuleFor(info => info.Name)
                .NotNull().WithMessage("Name is required. It is currently null");
            RuleFor(info => info.Condition)
                .IsInEnum().WithMessage("Condition is incorrect");
        }
    }
}
