using Costium.Domain.Exceptions;

namespace Costium.Domain.Entities;

public class ExpenseCategory: BaseEntity
{
    public string Description { get; private set; }

    private ExpenseCategory(string description)
    {
        Description = description;
    }

    public static ExpenseCategory Create(string description)
    {
        var descriptionValidated = ValidateDescription(description);
        return new ExpenseCategory(descriptionValidated);
    }

    public void UpdateDescription(string description)
    {
        Description = ValidateDescription(description);
    }

    private static string ValidateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Descrição da categoria é obrigatória.");

        if (description.Length > 50)
            throw new DomainException("Descrição não pode ter mais de 50 caracteres.");

        return description.Trim();
    }
}
