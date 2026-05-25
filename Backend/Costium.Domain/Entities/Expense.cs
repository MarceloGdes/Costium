using Costium.Domain.Enums;
using Costium.Domain.Exceptions;
using Costium.Domain.ValueObjects;

namespace Costium.Domain.Entities;

public class Expense : BaseEntity
{
    public int ExpenseIdNumber{ get; private set; }
    public string Description { get; private set; }
    public ExpenseType ExpenseType { get; private set; }
    public ExpenseCategory? ExpenseCategory { get; private set; }
    public Guid ExpenseCategoryId { get; private set; }

    private readonly List<ExpenseInstallment> _installments;
    public IReadOnlyCollection<ExpenseInstallment> Installments => _installments.AsReadOnly();
    public Money TotalAmount => _installments
    .Skip(1)
    .Aggregate(
        _installments.First().Amount,
        (acc, i) => acc.Add(i.Amount)
    );
    public int InstallmentCount => _installments.Count;
    
    private Expense(int expenseIdNumber, string description, ExpenseType expenseType, Guid expenseCategoryId, List<ExpenseInstallment> installments)
    {
        ExpenseIdNumber = expenseIdNumber;
        Description = description;
        ExpenseType = expenseType;
        ExpenseCategoryId = expenseCategoryId;
        _installments = installments;
    }

    public static Expense Create(int expenseIdNumber, string description, ExpenseType expenseType, Guid expenseCategoryId, List<ExpenseInstallment> installments)
    {
        if (expenseIdNumber <= 0)
            throw new DomainException("Número de identificação da despesa deve ser maior que zero.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Descrição é obrigatória.");

        if (description.Length > 255)
            throw new DomainException("Descrição deve ter até 255 caracteres.");

        if (expenseCategoryId == Guid.Empty)
            throw new DomainException("Categoria é obrigatória.");

        if (installments == null || !installments.Any())
            throw new DomainException("Pelo menos uma parcela é obrigatória.");
        return new Expense(expenseIdNumber, description, expenseType, expenseCategoryId, installments);
    }

}
