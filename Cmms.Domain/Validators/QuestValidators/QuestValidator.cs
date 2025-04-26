using Cmms.Domain.Entities.Quest;
using FluentValidation;


namespace Cmms.Domain.Validators.QuestValidators
{
    public class QuestValidator : AbstractValidator<Quest>
    {
        public QuestValidator()
        {
            RuleFor(info => info.Name)
                .NotNull().WithMessage("First name is required. It is currently null")
                .MinimumLength(3).WithMessage("First name must be at least 3 characters long")
                .MaximumLength(30).WithMessage("First name can contain at most 30 characters long");
            RuleFor(info => info.QuestTypeId)
                .NotNull().WithMessage("QuestType is required");
            RuleFor(info => info.QuestState)
                .NotNull().WithMessage("Quest state is required")
                .IsInEnum().WithMessage("Incorrect quest state");
        }
    }
}
