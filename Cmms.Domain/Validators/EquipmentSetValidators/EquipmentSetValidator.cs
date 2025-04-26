using Cmms.Domain.Entities.Equipments;
using Cmms.Domain.Entities.Quest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Domain.Validators.EquipmentSetValidators
{
    public class EquipmentSetValidator : AbstractValidator<EquipmentSet>
    {
        public EquipmentSetValidator()
        {
            RuleFor(info => info.Name)
                .NotNull().WithMessage("Name is required. It is currently null");
        }
    }
}
